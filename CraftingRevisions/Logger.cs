using MelonLoader;
using System.Reflection;

namespace CraftingRevisions;

internal static class Logger
{

	#region Log Functions
	//Regular Messages show in white
	internal static void Log(string message) => MelonLogger.Msg(message);

	//Warning Messages show in yellow
	internal static void LogWarning(string message) => MelonLogger.Warning(message);

	//Error Messages show in red
	internal static void LogError(string message) => MelonLogger.Error(message);

	//Blue Messages
	internal static void LogBlue(string message) => MelonLogger.Msg(ConsoleColor.Blue, message);

	//Green Messages
	internal static void LogGreen(string message) => MelonLogger.Msg(ConsoleColor.Green, message);

	//Debug Messages show only when in debug mode
	internal static void LogDebug(string message)
	{
//		if (Settings.instance.showDebugOutput) {
			Log(message);
//		}
	}
	//Not Debug Messages show only when not in debug mode
	internal static void LogNotDebug(string message)
	{
#if !DEBUG
		Log(message);
#endif
	}
	#endregion
}