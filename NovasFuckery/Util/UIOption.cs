using CustomUI.GameplaySettings;
using UnityEngine;

namespace NovasFuckery.Util
{
    internal class UIOption
    {
        internal bool Enabled;
        internal string Name { get; private set; }
        internal string Submenu { get; private set; }
        internal Sprite Sprite { get; private set; }
        private ToggleOption option;

        internal UIOption(string name, Sprite cranberry = null, string menuToAdd = "NovasFuckery", bool addToMenu = true) {
            Name = name;
            Sprite = cranberry;
            Submenu = menuToAdd;

            if (addToMenu) AddToSubmenu();
            
            FuckeryUI.Options.Add(this);
        }

        internal UIOption WithConflict(string name) {
            option.AddConflict(name);
            return this;
        }

        internal UIOption WithDescription(string desc) {
            option.hintText = desc;
            return this;
        }

        internal void AddToSubmenu () {
            option = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.ModifiersLeft, Name, Submenu, "", Sprite, 0);
            option.GetValue = Enabled;
            option.OnToggle += (value) => { Enabled = value; };
        }

        public static bool operator ==(UIOption option, bool value) {
            return option != null && option.Enabled == value;
        }

        public static bool operator !=(UIOption option, bool value) {
            return option != null && option.Enabled != value;
        }

        public override bool Equals(object obj) {
            return obj != null && ((UIOption) obj).Enabled == this.Enabled;
        }

        protected bool Equals(UIOption other) {
            return Enabled == other.Enabled && Equals(option, other.option) && string.Equals(Name, other.Name) && string.Equals(Submenu, other.Submenu) && Equals(Sprite, other.Sprite);
        }
    }
}
