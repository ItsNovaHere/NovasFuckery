﻿using CustomUI.GameplaySettings;
using System.Collections.Generic;
using UnityEngine;

namespace NovasFuckery.Util
{
    internal class UIOption
    {
        internal bool Enabled;
        internal string Name { get; private set; }
        internal string Submenu { get; private set; }
        internal Sprite Sprite { get; private set; }
        internal bool AllowedInChallengeMode { get; private set; }
        private ToggleOption option;

        internal UIOption(string name, string menuToAdd = "NovasFuckery", bool allowedInChallengeMode = true, Sprite cranberry = null, bool addToMenu = true) {
            Name = name;
            Sprite = cranberry;
            Submenu = menuToAdd;
            AllowedInChallengeMode = allowedInChallengeMode;

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

        //idk visual studio generated this don't complain to me
        public override int GetHashCode() {
            var hashCode = 1337733492;
            hashCode = hashCode * -1521134295 + Enabled.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Submenu);
            hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(Sprite);
            hashCode = hashCode * -1521134295 + AllowedInChallengeMode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ToggleOption>.Default.GetHashCode(option);
            return hashCode;
        }
    }
}
