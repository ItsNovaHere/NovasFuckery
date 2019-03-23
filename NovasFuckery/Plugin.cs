using Harmony;
using IllusionPlugin;
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
    public class Plugin : IPlugin {
        public string Name => "Nova's Fuckery";
        public string Version => "0.0.1";


        public void OnApplicationStart () {
            HarmonyInstance instance = HarmonyInstance.Create("com.itsnovahere.beatsaber.fuckery");
            instance.PatchAll(Assembly.GetExecutingAssembly());
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded (Scene arg0, LoadSceneMode arg1) {
            if(arg0.name == "MenuCore") {
                FuckeryUI.SetupUI();
            }

            if(arg0.name == "GameCore") {
                FuckeryMods.SetupMods();
            }
        }

        public void OnApplicationQuit () {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        #region Useless shit (like why is this still in iplugin)
        public void OnFixedUpdate () { }
        public void OnLevelWasInitialized (int level) { }
        public void OnLevelWasLoaded (int level) { }
        public void OnUpdate () { }
        #endregion
    }
}
