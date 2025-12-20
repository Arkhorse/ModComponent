using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;
using UnityEngine;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModCookingPotComponent : ModBaseComponent
{
	/// <summary>
	/// Can the item cook liquids?
	/// </summary>
	public bool CanCookLiquid;

	/// <summary>
	/// Can the item cook grub? <br/>
	/// Cookable canned food counts as grub.
	/// </summary>
	public bool CanCookGrub;

	/// <summary>
	/// Can the item cook meat?
	/// </summary>
	public bool CanCookMeat;

	/// <summary>
	/// The total water capacity of the item.
	/// </summary>
	public float Capacity;

	/// <summary>
	/// Template item to be used in the mapping process.
	/// </summary>
	public string Template = "";

	public Mesh? SnowMesh;
	public Mesh? WaterMesh;

	void Awake()
	{
		CopyFieldHandler.UpdateFieldValues(this);
	}

	public ModCookingPotComponent(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeComponent(JsonDict jsonDict, string className = "ModCookingPotComponent")
	{
		base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.CanCookLiquid = entry.GetBool("CanCookLiquid");
		this.CanCookGrub = entry.GetBool("CanCookGrub");
		this.CanCookMeat = entry.GetBool("CanCookMeat");
		this.Capacity = entry.GetFloat("Capacity");
		this.Template = entry.GetString("Template");
		this.SnowMesh = null;// GetChild(this.gameObject, jsonDict.GetVariant(className,"SnowMesh")).GetComponent<MeshFilter>().mesh;
		this.WaterMesh = null; // GetChild(this.gameObject, jsonDict.GetVariant(className,"WaterMesh")).GetComponent<MeshFilter>().mesh;
	}
}