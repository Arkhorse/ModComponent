using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using UnityEngine;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModMillableBehaviour : MonoBehaviour
{
	/// <summary>
	/// Can this item be restored from a ruined condition?
	/// </summary>
	public bool CanRestoreFromWornOut = false;

	/// <summary>
	/// The number of minutes it takes to restore this item from a ruined condition.
	/// </summary>
	public int RecoveryDurationMinutes = 1;

	/// <summary>
	/// The gear required to restore this item from a ruined condition.
	/// </summary>
	public string[] RestoreRequiredGear = Array.Empty<string>();

	/// <summary>
	/// The units of the gear required to restore this item from a ruined condition.
	/// </summary>
	public int[] RestoreRequiredGearUnits = Array.Empty<int>();

	/// <summary>
	/// The number of minutes it takes to repair this item.
	/// </summary>
	public int RepairDurationMinutes = 1;

	/// <summary>
	/// The gear required to repair this item.
	/// </summary>
	public string[] RepairRequiredGear = Array.Empty<string>();

	/// <summary>
	/// The units of the gear required to repair this item.
	/// </summary>
	public int[] RepairRequiredGearUnits = Array.Empty<int>();

	/// <summary>
	/// The skill associated with repairing this item.
	/// </summary>
	public SkillType Skill = SkillType.None;

	public ModMillableBehaviour(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal void InitializeBehaviour(JsonDict jsonDict, string className = "ModMillableBehaviour")
	{
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.RepairDurationMinutes = entry.GetInt("RepairDurationMinutes");
		this.RepairRequiredGear = entry.GetArray<string>("RepairRequiredGear");
		this.RepairRequiredGearUnits = entry.GetArray<int>("RepairRequiredGearUnits");
		this.CanRestoreFromWornOut = entry.GetBool("CanRestoreFromWornOut");
		this.RecoveryDurationMinutes = entry.GetInt("RecoveryDurationMinutes");
		this.RestoreRequiredGear = entry.GetArray<string>("RestoreRequiredGear");
		this.RestoreRequiredGearUnits = entry.GetArray<int>("RestoreRequiredGearUnits");
		this.Skill = entry.GetEnum<SkillType>("Skill");
	}
}
