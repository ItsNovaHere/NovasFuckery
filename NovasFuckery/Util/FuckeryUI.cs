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
        
        //Random
        internal static UIOption RandomPositionX;
        internal static UIOption RandomPositionY;
        internal static UIOption RandomDirection;
        internal static UIOption RandomColors;
        internal static UIOption RandomBombs;
        internal static UIOption RandomEverything;

        //MissHell
        internal static UIOption PauseOnMiss;
        internal static UIOption Saber180OnMiss;
        internal static UIOption RoomAdjustOnMiss;
        internal static UIOption AYYYYYOnMiss;

        //Megajump
        internal static UIOption MegaJump;
        internal static UIOption NJSFix;
        internal static UIOption Mirror;

        internal static bool Setup = false;

        internal static void SetupUI () {
            Options = new List<UIOption>();
            
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Nova's Fuckery", "MainMenu", "NovasFuckery", "have fun");

            ChallengeMode = new UIOption("Challenge Mode").WithDescription("Randomly enables and disables mods while you play.");
            OneAtATime = new UIOption("One At A Time");
            InvisibleSabers = new UIOption("Invisible Sabers");
            
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Randomize Things", "NovasFuckery", "Randomizers", "because why not");

            RandomEverything = new UIOption("Randomize All", null, "Randomizers");
            RandomPositionX = new UIOption("Random Note Line", null, "Randomizers");
            RandomPositionY = new UIOption("Random Note Layer", null, "Randomizers");
            RandomDirection = new UIOption("Random Note Direction", null, "Randomizers");
            RandomColors = new UIOption("Random Colors", null, "Randomizers");
            RandomBombs = new UIOption("Random Bombs", null, "Randomizers");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Miss Hell", "NovasFuckery", "MissHell", "have fun");

            PauseOnMiss = new UIOption("Pause On Miss", null, "MissHell");
            //Saber180OnMiss = new UIOption("Saber Flip On Miss", null, "MissHell");
            //RoomAdjustOnMiss = new UIOption("Room Adjust On Miss", null, "MissHell");
            AYYYYYOnMiss = new UIOption("AYYYY On Miss", null, "MissHell");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Mega Jump", "NovasFuckery", "MegaJump", "");

            MegaJump = new UIOption("Enabled", null, "MegaJump");
            NJSFix = new UIOption("Fix NJS", null, "MegaJump");
            Mirror = new UIOption("Mirror", null, "MegaJump");

            Setup = true;
        }

        internal static bool ModsEnabled() {
            return Options.Exists(x => x.Enabled);
        }
    }
}
