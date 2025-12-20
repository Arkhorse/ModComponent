using MelonLoader.TinyJSON;
using MelonLoader.Utils;
using ModComponent.API;
using ModComponent.API.Behaviours;
using ModComponent.API.Components;
using ModComponent.API.Modifications;
using ModComponent.Utils;
using UnityEngine;

namespace ModComponent.Mapper;

internal static class ComponentJson
{
	public static void InitializeComponents(GameObject prefab)
	{
		if (prefab == null)
		{
			throw new ArgumentNullException(nameof(prefab));
		}

		if (ComponentUtils.GetModComponent(prefab) != null)
		{
			return;
		}

		string name = NameUtils.RemoveGearPrefix(prefab.name);
		Logger.LogDebug($"Initializing components for {name}");
		try
		{
			string jsonData = JsonHandler.GetJsonText(name);
			if (string.IsNullOrEmpty(jsonData))
			{
				throw new Exception($"Json data for {name} was null or empty");
			}

			JsonDict jsonDict = JsonConvert.DeserializeObject<JsonDict>(jsonData);
			InitializeComponents(name, prefab, jsonDict);

		} catch (Exception e)
		{
			Logger.LogError($"Failed to initialize {name}:: {e}");
		}
	}

	#region InitializeComponents
	private static void InitializeComponents(string name, GameObject prefab, JsonDict jsonDict)
	{

		if (name == null)
		{
			throw new ArgumentNullException(nameof(name));
		}

		if (prefab == null)
		{
			throw new ArgumentNullException(nameof(prefab));
		}

		if (jsonDict == null)
		{
			throw new ArgumentNullException(nameof(jsonDict));
		}

		if (ComponentUtils.GetModComponent(prefab) != null)
		{
			return;
		}

		#region Mod Components
		if (jsonDict.ContainsKey("ModBedComponent"))
		{
			ModBedComponent newComponent = ComponentUtils.GetOrCreateComponent<ModBedComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModBodyHarvestComponent"))
		{
			ModBodyHarvestComponent newComponent = ComponentUtils.GetOrCreateComponent<ModBodyHarvestComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModCharcoalComponent"))
		{
			ModCharcoalComponent newComponent = ComponentUtils.GetOrCreateComponent<ModCharcoalComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModClothingComponent"))
		{
			ModClothingComponent newComponent = ComponentUtils.GetOrCreateComponent<ModClothingComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModCollectibleComponent"))
		{
			ModCollectibleComponent newComponent = ComponentUtils.GetOrCreateComponent<ModCollectibleComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModCookableComponent"))
		{
			ModCookableComponent newComponent = ComponentUtils.GetOrCreateComponent<ModCookableComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModCookingPotComponent"))
		{
			ModCookingPotComponent newComponent = ComponentUtils.GetOrCreateComponent<ModCookingPotComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModExplosiveComponent"))
		{
			ModExplosiveComponent newComponent = ComponentUtils.GetOrCreateComponent<ModExplosiveComponent>(prefab);
			newComponent.InitializeComponent(jsonDict, "ModExplosiveComponent");
		}
		else if (jsonDict.ContainsKey("ModFirstAidComponent"))
		{
			ModFirstAidComponent newComponent = ComponentUtils.GetOrCreateComponent<ModFirstAidComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModFoodComponent"))
		{
			ModFoodComponent newComponent = ComponentUtils.GetOrCreateComponent<ModFoodComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModGenericComponent"))
		{
			ModGenericComponent newComponent = ComponentUtils.GetOrCreateComponent<ModGenericComponent>(prefab);
			newComponent.InitializeComponent(jsonDict, "ModGenericComponent");
		}
		else if (jsonDict.ContainsKey("ModGenericEquippableComponent"))
		{
			ModGenericEquippableComponent newComponent = ComponentUtils.GetOrCreateComponent<ModGenericEquippableComponent>(prefab);
			newComponent.InitializeComponent(jsonDict, "ModGenericEquippableComponent");
		}
		else if (jsonDict.ContainsKey("ModLiquidComponent"))
		{
			ModLiquidComponent newComponent = ComponentUtils.GetOrCreateComponent<ModLiquidComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModPowderComponent"))
		{
			ModPowderComponent newComponent = ComponentUtils.GetOrCreateComponent<ModPowderComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModPurificationComponent"))
		{
			ModPurificationComponent newComponent = ComponentUtils.GetOrCreateComponent<ModPurificationComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModRandomItemComponent"))
		{
			ModRandomItemComponent newComponent = ComponentUtils.GetOrCreateComponent<ModRandomItemComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModRandomWeightedItemComponent"))
		{
			ModRandomWeightedItemComponent newComponent = ComponentUtils.GetOrCreateComponent<ModRandomWeightedItemComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModResearchComponent"))
		{
			ModResearchComponent newComponent = ComponentUtils.GetOrCreateComponent<ModResearchComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModToolComponent"))
		{
			ModToolComponent newComponent = ComponentUtils.GetOrCreateComponent<ModToolComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModAmmoComponent"))
		{
			ModAmmoComponent newComponent = ComponentUtils.GetOrCreateComponent<ModAmmoComponent>(prefab);
			newComponent.InitializeComponent(jsonDict);
		}
		#endregion

		#region Behaviour Components
		if (jsonDict.ContainsKey("ModAccelerantBehaviour"))
		{
			ModAccelerantBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModAccelerantBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModBurnableBehaviour"))
		{
			ModBurnableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModBurnableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModFireStarterBehaviour"))
		{
			ModFireStarterBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModFireStarterBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		else if (jsonDict.ContainsKey("ModTinderBehaviour"))
		{
			ModTinderBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModTinderBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModCarryingCapacityBehaviour"))
		{
			ModCarryingCapacityBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModCarryingCapacityBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModEvolveBehaviour"))
		{
			ModEvolveBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModEvolveBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModHarvestableBehaviour"))
		{
			ModHarvestableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModHarvestableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModMillableBehaviour"))
		{
			ModMillableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModMillableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModRepairableBehaviour"))
		{
			ModRepairableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModRepairableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModScentBehaviour"))
		{
			ModScentBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModScentBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModSharpenableBehaviour"))
		{
			ModSharpenableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModSharpenableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		if (jsonDict.ContainsKey("ModStackableBehaviour"))
		{
			ModStackableBehaviour newComponent = ComponentUtils.GetOrCreateComponent<ModStackableBehaviour>(prefab);
			newComponent.InitializeBehaviour(jsonDict);
		}
		#endregion

		#region Modifications
		if (jsonDict.ContainsKey("ChangeLayer"))
		{
			ChangeLayer newComponent = ComponentUtils.GetOrCreateComponent<ChangeLayer>(prefab);
			newComponent.InitializeModification(jsonDict);
		}
		#endregion
	}
	#endregion
}
