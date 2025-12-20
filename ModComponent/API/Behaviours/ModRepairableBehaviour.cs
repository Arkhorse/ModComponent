using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using UnityEngine;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModRepairableBehaviour : MonoBehaviour
{
	/// <summary>
	/// The audio to play while repairing.
	/// </summary>
	public string Audio = string.Empty;

	/// <summary>
	/// How many in-game minutes does it take to repair this item?
	/// </summary>
	public int Minutes;

	/// <summary>
	/// How much condition does repairing restore?
	/// </summary>
	public int Condition;

	/// <summary>
	/// The name of the tools suitable for repair. At least one of those will be required for repairing.<br/>
	/// Leave empty, if this item should be repairable without tools.
	/// </summary>
	public string[] RequiredTools = Array.Empty<string>();

	/// <summary>
	/// The name of the materials required for repair.
	/// </summary>
	public string[] MaterialNames = Array.Empty<string>();

	/// <summary>
	/// The number of the materials required for repair.
	/// </summary>
	public int[] MaterialCounts = Array.Empty<int>();

	public ModRepairableBehaviour(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal void InitializeBehaviour(JsonDict jsonDict, string className = "ModRepairableBehaviour")
	{
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.Audio = entry.GetString("Audio");
		this.Minutes = entry.GetInt("Minutes");
		this.Condition = entry.GetInt("Condition");
		this.RequiredTools = entry.GetArray<string>("RequiredTools");
		this.MaterialNames = entry.GetArray<string>("MaterialNames");
		this.MaterialCounts = entry.GetArray<int>("MaterialCounts");
	}
}