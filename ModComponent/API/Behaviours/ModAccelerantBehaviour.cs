using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModAccelerantBehaviour : ModFireMakingBaseBehaviour
{
	/// <summary>
	/// Is the item destroyed immediately after use?
	/// </summary>
	public bool DestroyedOnUse;

	public ModAccelerantBehaviour(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeBehaviour(JsonDict jsonDict, string className = "ModAccelerantBehaviour")
	{
		base.InitializeBehaviour(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.DestroyedOnUse = entry.GetBool("DestroyedOnUse", false);
	}
}