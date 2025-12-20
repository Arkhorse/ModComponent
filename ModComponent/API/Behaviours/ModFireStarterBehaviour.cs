using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;

namespace ModComponent.API.Behaviours;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModFireStarterBehaviour : ModFireMakingBaseBehaviour
{
	/// <summary>
	/// How many in-game seconds this item will take to ignite tinder.
	/// </summary>
	public float SecondsToIgniteTinder;

	/// <summary>
	/// How many in-game seconds this item will take to ignite a torch.
	/// </summary>
	public float SecondsToIgniteTorch;

	/// <summary>
	/// How many times can this item be used?
	/// </summary>
	public float NumberOfUses;

	/// <summary>
	/// Does the item require sunlight to work?
	/// </summary>
	public bool RequiresSunLight;

	/// <summary>
	/// What sound to play during usage. Not used for accelerants.
	/// </summary>
	public string OnUseSoundEvent = string.Empty;

	/// <summary>
	/// Set the condition to 0% after the fire starting finished (either successful or not).
	/// </summary>
	public bool RuinedAfterUse;

	/// <summary>
	/// Is the item destroyed immediately after use?
	/// </summary>
	public bool DestroyedOnUse;

	public ModFireStarterBehaviour(System.IntPtr intPtr) : base(intPtr) { }

	[HideFromIl2Cpp]
	internal override void InitializeBehaviour(JsonDict jsonDict, string className = "ModFireStarterBehaviour")
	{
		base.InitializeBehaviour(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

		this.DestroyedOnUse = entry.GetBool("DestroyedOnUse");
		this.NumberOfUses = entry.GetFloat("NumberOfUses");
		this.OnUseSoundEvent = entry.GetString("OnUseSoundEvent");
		this.RequiresSunLight = entry.GetBool("RequiresSunLight");
		this.RuinedAfterUse = entry.GetBool("RuinedAfterUse");
		this.SecondsToIgniteTinder = entry.GetFloat("SecondsToIgniteTinder");
		this.SecondsToIgniteTorch = entry.GetFloat("SecondsToIgniteTorch");
	}
}
