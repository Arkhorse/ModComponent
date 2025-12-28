using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using Il2CppTLD.Gear;
using MelonLoader.TinyJSON;
using ModComponent.Utils;
using UnityEngine;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public abstract partial class ModBaseComponent : MonoBehaviour
{
	/// <summary>
	/// How this item will be called in the DeveloperConsole. <br/>
	/// Leave empty for a sensible default.
	/// </summary>
	public string ConsoleName = "";

	/// <summary>
	/// Localization key to be used for the in-game name of the item.
	/// </summary>
	public string DisplayNameLocalizationId = "";

	/// <summary>
	/// Localization key to be used for the in-game description of the item.
	/// </summary>
	public string DescriptionLocalizatonId = "";

	/// <summary>
	/// The inventory category to be used for this item. <br/>
	/// Leave at 'Auto' for a sensible default.
	/// </summary>
	public ItemCategory InventoryCategory = ItemCategory.Auto;

	/// <summary>
	/// Localization key to be used for the 'Action' (e.g. 'Equip', 'Eat', ...) button in the inventory.<br/>
	/// The text is purely cosmetic and will not influcence the action the button triggers. <br/>
	/// Leave empty for a sensible default.
	/// </summary>
	public string InventoryActionLocalizationId = "";

	/// <summary>
	/// Sound to play when the item is picked up.
	/// </summary>
	public string PickUpAudio = "";

	/// <summary>
	/// Sound to play when the item is holstered.
	/// </summary>
	public string StowAudio = "Play_InventoryStow";

	/// <summary>
	/// Sound to play when the item is dropped.
	/// </summary>
	public string PutBackAudio = "";

	/// <summary>
	/// Sound to play when the item wore out during an action.
	/// </summary>
	public string WornOutAudio = "";

	/// <summary>
	/// The weight of the item in kilograms.
	/// </summary>
	public float WeightKG;

	/// <summary>
	/// The maximum hit points of the item.
	/// </summary>
	public float MaxHP;

	/// <summary>
	/// The number of days it takes for this item to decay - without use - from 100% to 0%. <br/>
	/// Leave at 0 if the item should not decay over time.
	/// </summary>
	public float DaysToDecay;

	/// <summary>
	/// The initial condition of the item when found or crafted.
	/// </summary>
	public GearStartCondition InitialCondition;

	/// <summary>
	/// Will the item be inspected when picked up? <br/>
	/// If not enabled, the item will go straight to the inventory.
	/// </summary>
	public bool InspectOnPickup;

	/// <summary>
	/// Distance from the camera during inspect.
	/// </summary>
	public float InspectDistance = 0.4f;

	/// <summary>
	/// Scales the item during inspect.
	/// </summary>
	public Vector3 InspectScale = Vector3.one;

	/// <summary>
	/// Each vector component stands for a rotation by the given degrees around the corresponding axis.
	/// </summary>
	public Vector3 InspectAngles = Vector3.zero;

	/// <summary>
	/// Offset from the center during inspect.
	/// </summary>
	public Vector3 InspectOffset = Vector3.zero;

	/// <summary>
	/// Model to show during inspect mode. <br/>
	/// NOTE: You must either set BOTH models or NO models.
	/// </summary>
	public GameObject? InspectModel;

	/// <summary>
	/// Model to show when not inspecting the item. <br/>
	/// NOTE: You must either set BOTH models or NO models.
	/// </summary>
	public GameObject? NormalModel;

	[HideFromIl2Cpp]
	public string GetEffectiveConsoleName()
	{
		if (string.IsNullOrEmpty(this.ConsoleName))
		{
			return this.name.Replace("GEAR_", ""); ;
		}

		return this.ConsoleName;
	}

	public ModBaseComponent(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal virtual void InitializeComponent(JsonDict jsonDict, string inheritanceName)
	{
		JsonDictEntry? entry = jsonDict.GetEntry(inheritanceName);

		this.ConsoleName = NameUtils.RemoveGearPrefix(this.gameObject.name);
		this.DisplayNameLocalizationId = entry.GetString("DisplayNameLocalizationId");
		this.DescriptionLocalizatonId = entry.GetString("DescriptionLocalizatonId");
		this.InventoryActionLocalizationId = entry.GetString("InventoryActionLocalizationId");
		this.WeightKG = entry.GetFloat("WeightKG");
		this.DaysToDecay = entry.GetFloat("DaysToDecay");
		this.MaxHP = entry.GetFloat("MaxHP");
		this.InitialCondition = entry.GetEnum<GearStartCondition>("InitialCondition");
		this.InventoryCategory = entry.GetEnum<ItemCategory>("InventoryCategory");
		this.PickUpAudio = entry.GetString("PickUpAudio");
		this.PutBackAudio = entry.GetString("PutBackAudio");
		this.StowAudio = entry.GetString("StowAudio");
		this.WornOutAudio = entry.GetString("WornOutAudio");
		this.InspectOnPickup = entry.GetBool("InspectOnPickup");
		this.InspectDistance = entry.GetFloat("InspectDistance", this.InspectDistance);
		this.InspectAngles = entry.GetVector3("InspectAngles");
		this.InspectOffset = entry.GetVector3("InspectOffset");
		this.InspectScale = entry.GetVector3("InspectScale");
		this.NormalModel = ModUtils.GetChild(this.gameObject, entry.GetString("NormalModel"));
		this.InspectModel = ModUtils.GetChild(this.gameObject, entry.GetString("InspectModel"));
		this.Validate();

	}

	internal virtual void Validate()
	{

	}
}
