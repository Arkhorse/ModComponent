using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModResearchComponent : ModBaseComponent
{
	public SkillType SkillType = SkillType.None;
	public int TimeRequirementHours = 5;
	public int SkillPoints = 10;
	public int NoBenefitAtSkillLevel = 4;
	public string ReadAudio = "Play_ResearchBook";

	public ModResearchComponent(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModResearchComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.SkillType = entry.GetEnum<SkillType>("SkillType");
		this.TimeRequirementHours = entry.GetInt("TimeRequirementHours");
		this.SkillPoints = entry.GetInt("SkillPoints");
		this.NoBenefitAtSkillLevel = entry.GetInt("NoBenefitAtSkillLevel");
		this.ReadAudio = entry.GetString("ReadAudio");
	}
}
