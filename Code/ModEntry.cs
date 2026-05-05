using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Logging;
using HarmonyLib;

namespace PiercingWailSound;

[ModInitializer("ModLoaded")]
public static class ModEntry
{
    public static void ModLoaded()
    {
        Log.Info("[PiercingWailSound] Loading...");
        new Harmony("com.tugboat006.piercingwailsound").PatchAll();
        Log.Info("[PiercingWailSound] Patches applied.");
    }
}
