using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using UnityEngine;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModCarryingCapacityBehaviour : MonoBehaviour
{
	/// <summary>
	/// The maximum buff to the carrying capacity from this item.
	/// </summary>
	public float MaxCarryCapacityKGBuff;

	public ModCarryingCapacityBehaviour(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal void InitializeBehaviour(JsonDict jsonDict, string className = "ModCarryingCapacityBehaviour")
	{
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.MaxCarryCapacityKGBuff = entry.GetFloat("MaxCarryCapacityKGBuff");
	}
}
