using System;
using System.Collections.Generic;
using CustomUI.GameplaySettings;
using UnityEngine;

namespace NovasFuckery.Util
{

    internal static class FuckeryUI {
        internal static List<UIOption> Options;

        internal static UIOption ChallengeMode;
        internal static UIOption OneAtATime;
        internal static UIOption InvisibleSabers;
        internal static UIOption UnlimitedDebris;
        
        //Random
        internal static UIOption RandomPositionX;
        internal static UIOption RandomPositionY;
        internal static UIOption RandomDirection;
        internal static UIOption RandomColors;
        internal static UIOption RandomBombs;
        internal static UIOption RandomEverything;

        //MissHell
        internal static UIOption PauseOnMiss;
        internal static UIOption AYYYYYOnMiss;

        //Megajump
        internal static UIOption MegaJump;
        internal static UIOption NJSFix;
        internal static UIOption Mirror;

        internal static bool Setup = false;

        internal static void SetupUI () {
            Options = new List<UIOption>();
            
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Nova's Fuckery", "MainMenu", "NovasFuckery", "have fun");

            ChallengeMode = new UIOption("Challenge Mode", "NovasFuckery", false).WithDescription("Randomly enables and disables mods while you play.");
            OneAtATime = new UIOption("One At A Time", "NovasFuckery", false);
            InvisibleSabers = new UIOption("Invisible Sabers", "NovasFuckery", false);
            UnlimitedDebris = new UIOption("Unlimited Debris");
            
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Randomize Things", "NovasFuckery", "Randomizers", "because why not");

            RandomEverything = new UIOption("Randomize All", "Randomizers");
            RandomPositionX = new UIOption("Random Note Line", "Randomizers");
            RandomPositionY = new UIOption("Random Note Layer", "Randomizers");
            RandomDirection = new UIOption("Random Note Direction", "Randomizers");
            RandomColors = new UIOption("Random Colors", "Randomizers");
            RandomBombs = new UIOption("Random Bombs", "Randomizers");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Miss Hell", "NovasFuckery", "MissHell", "have fun");

            PauseOnMiss = new UIOption("Pause On Miss", "MissHell");
            AYYYYYOnMiss = new UIOption("AYYYY On Miss", "MissHell");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Mega Jump", "NovasFuckery", "MegaJump", "");

            MegaJump = new UIOption("Enabled", "MegaJump");
            NJSFix = new UIOption("Fix NJS", "MegaJump");
            Mirror = new UIOption("Mirror", "MegaJump");

            Setup = true;
        }

        internal static void DisableAllMods(bool excludeChallengeMode) {
            foreach(var option in Options) {
                if(option.Name != "Challenge Mode") option.Enabled = false;
            }
        }

        internal static List<UIOption> GetActiveMods() {
            return Options.FindAll(x => x.Enabled);
        }

        internal static bool ModsEnabled() {
            return Options.Exists(x => x.Enabled);
        }
    }
}
