using CustomUI.GameplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NovasFuckery.Util
{
    internal class UIOption
    {
        internal bool Enabled;
        internal string Name { get; private set; }
        internal string Submenu { get; private set; }
        internal Sprite Sprite { get; private set; }

        internal UIOption(string name, Sprite cranberry = null, string menuToAdd = "NovasFuckery", bool addToMenu = true) {
            Name = name;
            Sprite = cranberry;
            Submenu = menuToAdd;

            if (addToMenu) AddToSubmenu();
        }

        internal void AddToSubmenu () {
            var option = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.ModifiersLeft, Name, Submenu, "", Sprite, 0);
            option.GetValue = Enabled;
            option.OnToggle += (value) => { Enabled = value; };
        }
    }
}
