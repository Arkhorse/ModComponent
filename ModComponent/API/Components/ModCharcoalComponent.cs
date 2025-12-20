using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;


namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModCharcoalComponent : ModBaseComponent
{
	public float SurveyGameMinutes = 15;
	public float SurveyRealSeconds = 3;
	public float SurveySkillExtendedHours = 1;
	public string SurveyLoopAudio = "Play_MapCharcoalWriting";
	public ModCharcoalComponent(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModCharcoalComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.SurveyGameMinutes = entry.GetFloat("SurveyGameMinutes");
		this.SurveyRealSeconds = entry.GetFloat("SurveyRealSeconds");
		this.SurveySkillExtendedHours = entry.GetFloat("SurveySkillExtendedHours");
		this.SurveyLoopAudio = entry.GetString("SurveyLoopAudio");
	}
}
