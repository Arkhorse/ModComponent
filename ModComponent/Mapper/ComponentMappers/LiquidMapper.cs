using Il2Cpp;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using ModComponent.API.Components;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;

namespace ModComponent.Mapper.ComponentMappers;

internal static class LiquidMapper
{
	internal static void Configure(ModBaseComponent modComponent)
	{
		ModLiquidComponent? modLiquidComponent = modComponent.TryCast<ModLiquidComponent>();
		if (modLiquidComponent == null)
		{
			return;
		}

		string lts = modLiquidComponent.LiquidType.GetLiquidTypeString();
		LiquidType lt = Addressables.LoadAssetAsync<LiquidType>(lts).WaitForCompletion();
		if (lt == null)
		{
			Logger.LogError($"Invalid LiquidType {lts} for {modComponent.name}");
			return;
		}

		LiquidItem liquidItem = ModComponent.Utils.ComponentUtils.GetOrCreateComponent<LiquidItem>(modComponent);
		liquidItem.m_LiquidCapacity = ItemLiquidVolume.FromLiters(modLiquidComponent.LiquidCapacityLiters);
		liquidItem.m_LiquidType = lt;
		liquidItem.m_Liquid = ItemLiquidVolume.FromLiters(modLiquidComponent.LiquidLiters);
		liquidItem.m_Maximum = ItemLiquidVolume.FromLiters(modLiquidComponent.LiquidCapacityLiters);
		liquidItem.m_Minimum = ItemLiquidVolume.FromLiters(modLiquidComponent.LiquidLiters);
		if (modLiquidComponent.RandomizeQuantity)
		{
			float rand = (modLiquidComponent.LiquidCapacityLiters / 16f)*UnityEngine.Random.Range(1f,16f);
			float randClamp = Math.Clamp(rand, modLiquidComponent.LiquidLiters, modLiquidComponent.LiquidCapacityLiters);
			liquidItem.m_Liquid = ItemLiquidVolume.FromLiters(randClamp);
		}
		//		liquidItem.m_DrinkingAudio = "Play_DrinkWater";
		//		liquidItem.m_TimeToDrinkSeconds = 4;
		//		liquidItem.m_LiquidQuality = LiquidQuality.Potable;
	}
}
