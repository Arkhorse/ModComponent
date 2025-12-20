using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GearSpawner;

[HarmonyPatch]
internal static class LootTableManager
{
	private static Dictionary<string, List<LootTableEntry>> lootTableEntries = new();
	private static List<int> processedLootTables = new();

	internal static void AddLootTableEntry(string lootTable, LootTableEntry entry)
	{
		string normalizedLootTableName = GetNormalizedLootTableName(lootTable);

		if (!lootTableEntries.TryGetValue(normalizedLootTableName, out List<LootTableEntry>? entryList))
		{
			entryList = new();
			lootTableEntries.Add(normalizedLootTableName, entryList);
		}

		entryList.Add(entry.Normalize());
	}

	internal static void ConfigureLootTableData(LootTableData lootTableData, string type = "container")
	{
		// empty loot table
		if (lootTableData == null)
		{
			return;
		}

		int instanceId = lootTableData.GetInstanceID();

		// already processed
		if (processedLootTables.Contains(instanceId))
		{
			return;
		}
		processedLootTables.Add(instanceId);

		List<LootTableEntry> entries;
		if (lootTableEntries.TryGetValue(lootTableData.name.ToLowerInvariant(), out entries))
		{


			Il2CppSystem.Collections.Generic.List<RandomTableDataEntry<AssetReferenceGearItem>> list = new();

			//Debug.Log($"Found LootTableData ({type}) | " + lootTableData.name.ToLowerInvariant() + " | " + lootTableData.m_BaseEntries.Count + " | " + entries.Count + " | " + lootTableData.GetInstanceID().ToString());

			List<string> has = new();
			foreach (RandomTableDataEntry<AssetReferenceGearItem> R in lootTableData.m_BaseEntries)
			{
				has.Add(R.m_Item.AssetGUID);
				//Debug.Log(R.m_Item.AssetGUID + " => " + R.m_Weight + " | " + R.m_Item?.LoadAssetAsync()?.WaitForCompletion()?.name);
			}

			int added = 0;
			foreach (LootTableEntry entry in entries)
			{
				if (!has.Contains(entry.PrefabName))
				{
					RandomTableDataEntry<AssetReferenceGearItem> newEntry = new();
					newEntry.m_Item = new AssetReferenceGearItem(entry.PrefabName);
					newEntry.m_Weight = entry.Weight;

					lootTableData.m_BaseEntries.Add(newEntry);
					lootTableData.m_FilteredExtendedItems.Add(newEntry.m_Item);
					lootTableData.m_ExistingOperations.Add(new IKeyEvaluator(newEntry.m_Item.Pointer), newEntry.m_Item.LoadAssetAsync());

					//Debug.Log(entry.PrefabName + " => " + entry.Weight);

					added++;
				}
			}

			if (added > 0)
			{
				MelonLogger.Msg("Processed " + added + " items for " + lootTableData.name.ToLowerInvariant() + $"({type})");
			}
		}
		else
		{
			//Debug.Log($"Found LootTableData ({type}) | " + lootTableData.name.ToLowerInvariant() + " | " + lootTableData.m_BaseEntries.Count + " | " + lootTableData.GetInstanceID().ToString());

		}


	}

	private static string GetNormalizedLootTableName(string lootTable)
	{
		if (lootTable.StartsWith("Loot", System.StringComparison.InvariantCultureIgnoreCase))
		{
			return lootTable.ToLowerInvariant();
		}
		if (lootTable.StartsWith("Cargo", System.StringComparison.InvariantCultureIgnoreCase))
		{
			return "loot" + lootTable.ToLowerInvariant();
		}
		return "loottable" + lootTable.ToLowerInvariant();
	}


	[HarmonyPrefix]
	[HarmonyPatch(typeof(Container), nameof(Container.PopulateWithRandomGear))]
	private static void Container_PopulateWithRandomGear(Container __instance)
	{
		//		MelonLoader.MelonLogger.Warning("Container_PopulateWithRandomGear | " + __instance.name);

		if (__instance.m_LootTable != null)
		{
			//			MelonLoader.MelonLogger.Warning("Container_PopulateWithRandomGear m_LootTable | " + __instance.name + " | " + __instance.m_LootTable.CanDrawFromTable.ToString());
			ConfigureLootTableData(__instance.m_LootTable);
		}
		if (__instance.m_LootTableData != null)
		{
			//			MelonLoader.MelonLogger.Warning("Container_PopulateWithRandomGear m_LootTableData | " + __instance.name + " | " + __instance.m_LootTableData.CanDrawFromTable.ToString());
			ConfigureLootTableData(__instance.m_LootTableData);
		}
		if (__instance.m_LockedLootTableData != null)
		{
			//			MelonLoader.MelonLogger.Warning("Container_PopulateWithRandomGear m_LockedLootTableData | " + __instance.name + " | " + __instance.m_LockedLootTableData.CanDrawFromTable.ToString());
			ConfigureLootTableData(__instance.m_LockedLootTableData);
		}
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(IceFishingHole), nameof(IceFishingHole.Awake))]
	private static void IceFishingHole_Awake(IceFishingHole __instance)
	{
		if (__instance.m_LootTable != null)
		{
			ConfigureLootTableData(__instance.m_LootTable, "FishingHole");
		}
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(RadialObjectSpawner), nameof(RadialObjectSpawner.Awake))]
	private static void RadialObjectSpawner_Awake(RadialObjectSpawner __instance)
	{
		if (__instance.m_LootTableData != null)
		{
			ConfigureLootTableData(__instance.m_LootTableData, "RadialSpawner");
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(IceFishingHole), nameof(IceFishingHole.InstantiateFish), new Type[] { typeof(AssetReference) })]
	private static void IceFishingHole_InstantiateFish(IceFishingHole __instance, AssetReference fishReference, ref bool __runOriginal, ref GearItem __result)
	{
		//		Debug.Log($"InstantiateFish: {fishReference.AssetGUID} {fishReference.GetType().ToString()} {fishReference.RuntimeKey.ToString()} {fishReference.RuntimeKeyIsValid()} {fishReference.IsValid()}");

		GameObject go = Addressables.LoadAssetAsync<GameObject>(fishReference.RuntimeKey).WaitForCompletion();
		if (go != null)
		{
			GameObject newGo = GameObject.Instantiate(go);
			//		Debug.Log($"InstantiateFish: {newGo.name} {newGo.GetComponent<GearItem>()!=null} {newGo.GetComponent<FoodWeight>() != null} {newGo.GetComponent<HarvestFish>() != null}");
			if (newGo.GetComponent<GearItem>() != null && newGo.GetComponent<HarvestFish>() == null)
			{
				GearItem gi = newGo.GetComponent<GearItem>();
				//				gi.RollGearCondition(false);
				//				gi.MaybeRollRandomWeightAndCalories();

				__result = gi;
				__runOriginal = false;
			}
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(SaveGameSystem), nameof(SaveGameSystem.LoadSceneData), new Type[] { typeof(string), typeof(string) })]
	private static void SaveGameSystem_LoadSceneData(SaveGameSystem __instance, string name, string sceneSaveName)
	{
		processedLootTables.Clear();
	}

}
