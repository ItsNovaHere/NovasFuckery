using Harmony;
using IPA;
using IPA.Old;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace NovasFuckery
{
    public class Plugin : IBeatSaberPlugin {

        public void OnApplicationStart () {
            HarmonyInstance instance = HarmonyInstance.Create("com.itsnovahere.beatsaber.fuckery");
            instance.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnSceneLoaded(Scene arg0, LoadSceneMode sceneMode) {
            if (arg0.name == "MenuCore") {
                FuckeryUI.SetupUI();
            }

            if (arg0.name == "GameCore" && FuckeryUI.Setup) {
                FuckeryMods.SetupMods();
            }
        }



        #region Useless shit (like why is this still in iplugin)
        public void OnFixedUpdate () { }
        public void OnLevelWasInitialized (int level) { }
        public void OnLevelWasLoaded (int level) { }
        public void OnUpdate () { }
        public void OnSceneUnloaded(Scene scene) { }
        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }
        public void OnApplicationQuit() { }
        #endregion
    }
}
