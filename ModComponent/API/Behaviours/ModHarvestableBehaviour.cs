using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using UnityEngine;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModHarvestableBehaviour : MonoBehaviour
{
	/// <summary>
	/// The audio to play while harvesting
	/// </summary>
	public string Audio = string.Empty;

	/// <summary>
	/// How many in-game minutes does it take to harvest this item?
	/// </summary>
	public int Minutes;

	/// <summary>
	/// The names of the GearItems harvesting will yield
	/// </summary>
	public string[] YieldNames = Array.Empty<string>();

	/// <summary>
	/// The number of the GearItems harvesting will yield
	/// </summary>
	public int[] YieldCounts = Array.Empty<int>();

	/// <summary>
	/// The names of the ToolItems that can be used to harvest. Leave empty for harvesting by hand.
	/// </summary>
	public string[] RequiredToolNames = Array.Empty<string>();

	public ModHarvestableBehaviour(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal void InitializeBehaviour(JsonDict jsonDict, string className = "ModHarvestableBehaviour")
	{
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.Audio = entry.GetString("Audio");
		this.Minutes = entry.GetInt("Minutes");
		this.YieldCounts = entry.GetArray<int>("YieldCounts");
		this.YieldNames = entry.GetArray<string>("YieldNames");
		this.RequiredToolNames = entry.GetArray<string>("RequiredToolNames");
	}
}