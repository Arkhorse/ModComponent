using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModPurificationComponent : ModBaseComponent
{
	public float LitersPurify = 1f;
	public float ProgressBarDurationSeconds = 5f;
	public string ProgressBarLocalizationID = "GAMEPLAY_PurifyingWater";
	public string PurifyAudio = "Play_WaterPurification";

	public ModPurificationComponent(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModPurificationComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.LitersPurify = entry.GetFloat("LitersPurify");
		this.ProgressBarDurationSeconds = entry.GetFloat("ProgressBarDurationSeconds");
		this.ProgressBarLocalizationID = entry.GetString("ProgressBarLocalizationID");
		this.PurifyAudio = entry.GetString("PurifyAudio");
	}
}
