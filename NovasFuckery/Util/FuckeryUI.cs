using CustomUI.GameplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovasFuckery.Util {
    class FuckeryUI {
        internal static UIOption OneAtATime;
        internal static UIOption RandomPositionX;
        internal static UIOption RandomPositionY;
        internal static UIOption RandomDirection;
        internal static UIOption RandomColors;
        internal static UIOption RandomBombs;
        internal static UIOption RandomEverything;
        internal static UIOption InvisibleSabers;
        
        //Megajump
        internal static UIOption MegaJump;
        internal static UIOption NJSFix;
        internal static UIOption Mirror;

        internal static bool Setup = false;

        internal static void SetupUI () {
            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Nova's Fuckery", "MainMenu", "NovasFuckery", "have fun");

            OneAtATime = new UIOption("One At A Time");
            InvisibleSabers = new UIOption("Invisible Sabers");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Randomize Things", "NovasFuckery", "Randomizers", "because why not");

            RandomEverything = new UIOption("Randomize All", null, "Randomizers");
            RandomPositionX = new UIOption("Random Note Line", null, "Randomizers");
            RandomPositionY = new UIOption("Random Note Layer", null, "Randomizers");
            RandomDirection = new UIOption("Random Note Direction", null, "Randomizers");
            RandomColors = new UIOption("Random Colors", null, "Randomizers");
            RandomBombs = new UIOption("Random Bombs", null, "Randomizers");

            GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "Mega Jump", "NovasFuckery", "MegaJump", "");

            MegaJump = new UIOption("Enabled", null, "MegaJump");
            NJSFix = new UIOption("Fix NJS", null, "MegaJump");
            Mirror = new UIOption("Mirror", null, "MegaJump");

            Setup = true;
        }
    }
}
