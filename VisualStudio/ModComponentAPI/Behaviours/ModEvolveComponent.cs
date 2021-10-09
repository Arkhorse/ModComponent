﻿using UnityEngine;

namespace ModComponentAPI
{
	[MelonLoader.RegisterTypeInIl2Cpp]
	public class ModEvolveComponent : MonoBehaviour
	{
		/// <summary>
		/// Name of the item into which this item will. E.g. 'GEAR_GutDried'
		/// </summary>
		public string TargetItemName;

		/// <summary>
		/// Does this item only evolve when it is stored indoors?
		/// </summary>
		public bool IndoorsOnly;

		/// <summary>
		/// How many in-game hours does this item take to evolve from 0% to 100%?
		/// </summary>
		public int EvolveHours = 1;

		public ModEvolveComponent(System.IntPtr intPtr) : base(intPtr) { }
	}
}