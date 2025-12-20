using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public partial class ModCollectibleComponent : ModBaseComponent
{
	/// <summary>
	/// The localization id for the hud message displayed after this item is picked up.
	/// </summary>
	public string HudMessageLocalizationId = "";

	/// <summary>
	/// The localization id for the narrative content of the item.
	/// </summary>
	public string NarrativeTextLocalizationId = "";

	/// <summary>
	/// The alignment of the narrative text. Options are "Automatic", "Left", "Center", "Right", and "Justified"
	/// </summary>
	public NGUIText.Alignment TextAlignment = NGUIText.Alignment.Automatic;

	public ModCollectibleComponent(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModCollectibleComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.HudMessageLocalizationId = entry.GetString("HudMessageLocalizationId");
		this.NarrativeTextLocalizationId = entry.GetString("NarrativeTextLocalizationId");
		this.TextAlignment = entry.GetEnum<NGUIText.Alignment>("TextAlignment");
	}
}
