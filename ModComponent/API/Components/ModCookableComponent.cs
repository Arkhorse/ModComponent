using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;
using UnityEngine;
using static Il2Cpp.Cookable;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public partial class ModCookableComponent : ModBaseComponent
{
	/// <summary>
	/// Can this be cooked/heated?<br/>
	/// If not enabled, the other settings in this section will be ignored.
	/// </summary>
	public bool Cooking;

	/// <summary>
	/// What type of cookable is this? <br/>
	/// Affects where and how this item can be cooked.
	/// </summary>
	public CookableType Type = CookableType.Meat;

	/// <summary>
	/// How many in-game minutes does it take to cook/heat this item?
	/// </summary>
	public int CookingMinutes = 1;

	/// <summary>
	/// How many in-game minutes until this items becomes burnt after being 'cooked'?
	/// </summary>
	public int BurntMinutes = 1;

	/// <summary>
	/// How many liters of water are required for cooking this item? Only potable water applies.
	/// </summary>
	public float CookingWaterRequired;

	/// <summary>
	/// How many units of this item are required for cooking?
	/// </summary>
	public int CookingUnitsRequired = 1;

	/// <summary>
	/// Convert the item into this item when cooking completes. <br/>
	/// Leave empty to only heat the item without converting it.
	/// </summary>
	public GameObject? CookingResult;

	/// <summary>
	/// Sound to use when cooking/heating the item. <br/>
	/// Leave empty for a sensible default.
	/// </summary>
	public string CookingAudio = "";

	/// <summary>
	/// Sound to use when putting the item into a pot or on a stove. <br/>
	/// Leave empty for a sensible default.
	/// </summary>
	public string StartCookingAudio = "";

	void Awake()
	{
		CopyFieldHandler.UpdateFieldValues(this);
	}

	public ModCookableComponent(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModCookableComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.BurntMinutes = entry.GetInt("BurntMinutes");
		this.Cooking = entry.GetBool("Cooking");
		this.CookingAudio = entry.GetString("CookingAudio");
		this.StartCookingAudio = entry.GetString("StartCookingAudio");
		this.CookingMinutes = entry.GetInt("CookingMinutes");
		if (string.IsNullOrEmpty(entry.GetString(className, "CookingResult")))
		{
			this.CookingResult = null;
		}
		else
		{
			string assetName = entry.GetString("CookingResult").ToString();
			this.CookingResult = AssetBundleUtils.LoadAsset<GameObject>(assetName);
		}
		this.CookingUnitsRequired = entry.GetInt("CookingUnitsRequired");
		this.CookingWaterRequired = entry.GetFloat("CookingWaterRequired");
		this.Type = entry.GetEnum<CookableType>("Type");
	}
}
