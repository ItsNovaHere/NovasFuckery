using BS_Utils.Utilities;
using Harmony;
using NovasFuckery.Util;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectSpawnController))]
    [HarmonyPatch("BeatmapObjectSpawnCallback", MethodType.Normal)]
    class BeatmapObjectSpawnControllerCallback
    {
        static void Prefix (ref BeatmapObjectData beatmapObjectData) {
            if (beatmapObjectData.beatmapObjectType == BeatmapObjectType.Note) {
                var noteData = (NoteData) beatmapObjectData;

                if (FuckeryUI.RandomEverything.Enabled) {
                    var layer = (NoteLineLayer) UnityEngine.Random.Range(0, 3);
                    noteData.SetProperty("noteLineLayer", layer);
                    noteData.SetProperty("startNoteLineLayer", layer);

                    noteData.SetProperty("lineIndex", UnityEngine.Random.Range(0, 4));

                    switch (UnityEngine.Random.Range(0, 3)) {
                        case 0:
                            break;
                        case 1:
                            noteData.SwitchNoteType();
                            break;
                        case 2:
                            noteData.SetProperty("noteType", NoteType.Bomb);
                            break;
                    }
                    return;
                }

                if (FuckeryUI.RandomPositionY.Enabled) {
                    var layer = (NoteLineLayer) UnityEngine.Random.Range(0, 3);
                    noteData.SetProperty("noteLineLayer", layer);
                    noteData.SetProperty("startNoteLineLayer", layer);
                }

                if (FuckeryUI.RandomPositionX.Enabled) {
                    noteData.SetProperty("lineIndex", UnityEngine.Random.Range(0, 4));
                }

                if (FuckeryUI.RandomDirection.Enabled && noteData.noteType.IsBasicNote()) {
                    noteData.SetProperty("cutDirection", (NoteCutDirection) UnityEngine.Random.Range(1, 7));
                }

                if(FuckeryUI.RandomColors.Enabled && FuckeryUI.RandomBombs.Enabled) {
                    switch(UnityEngine.Random.Range(0, 3)) {
                        case 0:
                            break;
                        case 1:
                            noteData.SwitchNoteType();
                            break;
                        case 2:
                            noteData.SetProperty("noteType", NoteType.Bomb);
                            break;
                    }
                } else if (FuckeryUI.RandomColors.Enabled) {
                    if(UnityEngine.Random.Range(0, 2) == 1) {
                        noteData.SwitchNoteType();
                    }
                } else if (FuckeryUI.RandomBombs.Enabled) {
                    if (UnityEngine.Random.Range(0, 2) == 1) {
                        noteData.SetProperty("noteType", NoteType.Bomb);
                    }
                }
            }
        }
    }
}
