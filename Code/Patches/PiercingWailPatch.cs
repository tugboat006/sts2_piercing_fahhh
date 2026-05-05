using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Entities.Cards;
using System.Threading.Tasks;

namespace PiercingWailSound.Patches;

[HarmonyPatch(typeof(PiercingWail), "OnPlay")]
public static class PiercingWailPatch
{
    private static readonly string AudioPath = System.IO.Path.Combine(
        System.IO.Path.GetDirectoryName(typeof(PiercingWailPatch).Assembly.Location)!,
        "assets", "audio", "piercing_wail_sfx.ogg"
    );

    private static AudioStream? _audio;

    [HarmonyPostfix]
    public static void Postfix(PiercingWail __instance)
    {
        try
        {
            PlayCustomSfx();
        }
        catch (System.Exception ex)
        {
            Log.Error($"[PiercingWailSound] Patch error: {ex}");
        }
    }

    private static void PlayCustomSfx()
    {
        if (_audio == null)
        {
            if (!System.IO.File.Exists(AudioPath))
            {
                Log.Error($"[PiercingWailSound] Audio not found at: {AudioPath}");
                return;
            }
            _audio = AudioStreamOggVorbis.LoadFromFile(AudioPath);
            if (_audio == null)
            {
                Log.Error("[PiercingWailSound] Failed to load OGG file.");
                return;
            }
        }

        var player = new AudioStreamPlayer();
        player.Stream = _audio;
        player.VolumeDb = 0f;
        player.Bus = "Master";

        var scene = Engine.GetMainLoop() as SceneTree;
        scene?.CurrentScene?.AddChild(player);
        player.Play();
        player.Finished += player.QueueFree;

        Log.Info("[PiercingWailSound] Custom SFX triggered.");
    }
}