﻿using Il2Cpp;
using HarmonyLib;

using ModComponent.API.Components;

namespace ModComponent.Patches;

internal static class AlternativePowderPatches
{
	[HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.AddPowderToInventory))]
	private static class PlayerManager_AddPowderToInventory
	{
		private static bool Prefix(PlayerManager __instance, float amount, GearPowderType type)
		{
			ModPowderComponent.ModPowderType modPowderType = ModPowderComponent.GetPowderType(type);
			if (modPowderType == ModPowderComponent.ModPowderType.Gunpowder)
			{
				return true;
			}

			float num = amount;
			foreach (Il2CppTLD.Gear.GearItemObject gearItemObject in GameManager.GetInventoryComponent().m_Items)
			{
				GearItem gearItem = gearItemObject.m_GearItem;
				if (gearItem && gearItem.m_PowderItem && gearItem.m_PowderItem.m_Type == type)
				{
					num = gearItem.m_PowderItem.Add(num);
				}
			}
			
			return false;
		}
	}
}
