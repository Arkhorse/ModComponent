using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModAmmoComponent : ModBaseComponent
{

	public ModAmmoComponent(IntPtr intPtr) : base(intPtr) { }

	/// <summary>
	/// (Il2Cpp.GunType) The type of gun this bullet is compatible with.
	/// </summary>
	public GunType AmmoForGunType;

    void Awake()
    {
        CopyFieldHandler.UpdateFieldValues(this);
    }

    [HideFromIl2Cpp]
    internal override void InitializeComponent(JsonDict jsonDict, string className = "ModAmmoComponent")
    {
        base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		AmmoForGunType = entry.GetEnum<GunType>("AmmoForGunType");
	}
}