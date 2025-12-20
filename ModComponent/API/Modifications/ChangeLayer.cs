using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;
using UnityEngine;

namespace ModComponent.API.Modifications;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ChangeLayer : MonoBehaviour
{
	public int Layer;
	public bool Recursively;

	public void Start()
	{
		CopyFieldHandler.UpdateFieldValues(this);
		this.Invoke("SetLayer", 1);
	}

	internal void SetLayer()
	{
		vp_Layer.Set(this.gameObject, Layer, Recursively);
		Destroy(this);
	}

	public ChangeLayer(IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal void InitializeModification(JsonDict jsonDict, string inheritanceName = "ChangeLayer")
	{
		JsonDictEntry? jsonDictEntry = jsonDict.GetEntry(inheritanceName);
		if (jsonDictEntry != null)
		{
			this.Recursively = jsonDictEntry.GetBool("Recursively");
			this.Layer = jsonDictEntry.GetInt("Layer");
		}
	}
}