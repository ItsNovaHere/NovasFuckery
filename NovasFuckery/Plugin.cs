using Harmony;
using IPA;
using NovasFuckery.Util;
using System.Reflection;
using IPA.Logging;
using UnityEngine.SceneManagement;
using System.Media;
using System.Collections.Generic;

namespace NovasFuckery
{
    public class Plugin : IBeatSaberPlugin {
        public static Logger Logger;

        #region AYYYYYYY on miss
        public static SoundPlayer Miss1 = new SoundPlayer(Properties.Resources.Miss_02);
        public static SoundPlayer Miss2 = new SoundPlayer(Properties.Resources.Miss_03);
        public static SoundPlayer Miss3 = new SoundPlayer(Properties.Resources.Miss_04);
        public static SoundPlayer Miss4 = new SoundPlayer(Properties.Resources.Miss_05);
        public static SoundPlayer Miss5 = new SoundPlayer(Properties.Resources.Miss_06);
        public static SoundPlayer Miss6 = new SoundPlayer(Properties.Resources.Miss_07);
        public static SoundPlayer Miss7 = new SoundPlayer(Properties.Resources.Miss_08);
        public static SoundPlayer Miss8 = new SoundPlayer(Properties.Resources.Miss_09);
        public static SoundPlayer Miss9 = new SoundPlayer(Properties.Resources.Miss_10);
        public static SoundPlayer Miss10 = new SoundPlayer(Properties.Resources.Miss_11);
        public static SoundPlayer Miss11 = new SoundPlayer(Properties.Resources.Miss_12);
        public static SoundPlayer Miss12 = new SoundPlayer(Properties.Resources.Miss_13);
        public static SoundPlayer Miss13 = new SoundPlayer(Properties.Resources.Miss_14);
        public static SoundPlayer Miss14 = new SoundPlayer(Properties.Resources.Miss_15);

        public static SoundPlayer Fail = new SoundPlayer(Properties.Resources.Fail);

        #endregion

        public static List<SoundPlayer> MissSounds = new List<SoundPlayer>();

        public void OnApplicationStart () {
            HarmonyInstance instance = HarmonyInstance.Create("com.itsnovahere.beatsaber.fuckery");
            instance.PatchAll(Assembly.GetExecutingAssembly());

            MissSounds.Add(Miss1);
            MissSounds.Add(Miss2);
            MissSounds.Add(Miss3);
            MissSounds.Add(Miss4);
            MissSounds.Add(Miss5);
            MissSounds.Add(Miss6);
            MissSounds.Add(Miss7);
            MissSounds.Add(Miss8);
            MissSounds.Add(Miss9);
            MissSounds.Add(Miss10);
            MissSounds.Add(Miss11);
            MissSounds.Add(Miss12);
            MissSounds.Add(Miss13);
            MissSounds.Add(Miss14);
        }

        public void OnSceneLoaded(Scene arg0, LoadSceneMode sceneMode) {
            if (arg0.name == "MenuCore") FuckeryUI.SetupUI();
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) {
            if (nextScene.name == "GameCore" && FuckeryUI.Setup) FuckeryMods.SetupMods();
        }

        public void Init(object idc, Logger logger) {
            Logger = logger;
        }

        #region Useless shit (like why is this still in iplugin)
        public void OnFixedUpdate () { }
        public void OnLevelWasInitialized (int level) { }
        public void OnLevelWasLoaded (int level) { }
        public void OnUpdate () { }
        public void OnSceneUnloaded(Scene scene) { }
        
        public void OnApplicationQuit() { }
        #endregion
    }
}
