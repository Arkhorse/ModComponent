using Harmony;
using Il2Cpp;
using ModComponent.API.Components;
using ModComponent.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModComponent.Mapper;

internal static class AlternativeToolManager
{
	private static List<ModToolComponent> toolList = new();
	private static List<string> templateNameList = new();

	internal static void AddToList(ModToolComponent alternateTool, string templateName)
	{
		toolList.Add(alternateTool);
		templateNameList.Add(templateName);
	}

	private static void Clear()
	{
		toolList = new();
		templateNameList = new();
	}

	internal static void ProcessList()
	{
		for (int i = 0; i < toolList.Count; i++)
		{
			AddAlternativeTool(toolList[i], templateNameList[i]);
		}
		Clear();
	}

	private static void AddAlternativeTool(ModToolComponent modToolComponent, string templateName)
	{
		GameObject original = AssetBundleUtils.LoadAsset<GameObject>(templateName);
		if (original == null)
		{
			return;
		}

		AlternateTools alternateTools = ModComponent.Utils.ComponentUtils.GetOrCreateComponent<AlternateTools>(original);
		List<AssetReferenceGearItem> list = new();
		if (alternateTools.m_AlternateTools.Count() > 0)
		{
			list.AddRange(alternateTools.m_AlternateTools);
		}
		list.Add(new AssetReferenceGearItem(templateName));
		alternateTools.m_AlternateTools = list.ToArray();
	}
}
