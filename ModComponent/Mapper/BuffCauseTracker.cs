﻿extern alias Hinterland;
using HarmonyLib;
using Hinterland;
using System.Collections.Generic;

namespace ModComponent.Mapper;

internal static class BuffCauseTracker
{
	private static Dictionary<AfflictionType, string> causes = new Dictionary<AfflictionType, string>();

	public static void SetCause(AfflictionType buff, string cause)
	{
		if (causes.ContainsKey(buff))
		{
			causes[buff] = cause;
		}
		else
		{
			causes.Add(buff, cause);
		}
	}

	public static string GetCause(AfflictionType buff)
	{
		causes.TryGetValue(buff, out string result);
		return result;
	}
}

[HarmonyPatch(typeof(FatigueBuff), "Apply")]//Exists
internal static class FagtigueBuffApplyPatch
{
	public static void Postfix(FatigueBuff __instance)
	{
		GearItem gearItem = Utils.ComponentUtils.GetComponentSafe<GearItem>(__instance);
		if (gearItem == null)
		{
			return;
		}
		else
		{
			BuffCauseTracker.SetCause(AfflictionType.ReducedFatigue, gearItem.m_LocalizedDisplayName.Text());
		}
	}
}

[HarmonyPatch(typeof(AfflictionButton), "SetCauseAndEffect")]//positive caller count
internal static class AfflictionButtonSetCauseAndEffectPatch
{
	public static void Prefix(ref string causeStr, AfflictionType affType)
	{
		string trackedCause = BuffCauseTracker.GetCause(affType);
		if (!string.IsNullOrEmpty(trackedCause))
		{
			causeStr = trackedCause;
		}
	}
}
