using ModSettings;

namespace CraftingRevisions
{
	public class Settings : JsonModSettings
	{
		public static Settings instance = new Settings();

		[Name("Crafting Menu Scroll Steps")]
		[Description("Number of steps moved in the crafting menu for one scroll. Default = 7")]
		[Slider(1, 7)]
		public int numCraftingSteps = 1;
	}
}
