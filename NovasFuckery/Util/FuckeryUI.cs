using CustomUI.GameplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovasFuckery.Util {
    class FuckeryUI {
        internal static UIOption OneAtATime;
        internal static UIOption RandomPosition;
        internal static UIOption MildAnnoyance;
        
        //Megajump
        internal static UIOption MegaJump;
        internal static UIOption NJSFix;
        internal static UIOption Mirror;

        internal static void SetupUI () {
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Nova's Fuckery", "MainMenu", "NovasFuckery", "have fun");

            OneAtATime = new UIOption("One At A Time");
            RandomPosition = new UIOption("Random Position");
            MildAnnoyance = new UIOption("Mild Annoyance");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Mega Jump", "NovasFuckery", "MegaJump", "");

            MegaJump = new UIOption("Enabled", null, "MegaJump");
            NJSFix = new UIOption("Fix NJS", null, "MegaJump");
            Mirror = new UIOption("Mirror", null, "MegaJump");
        }
    }
}
