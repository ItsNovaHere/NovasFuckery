using BS_Utils.Gameplay;
using NovasFuckery.MonoBehaviours;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BS_Utils.Utilities;
using System.Collections;
using Harmony;
using System.Reflection;

namespace NovasFuckery
{
    class FuckeryMods
    {
        internal static void SetupMods () {
            bool disableScore = false;

            if (FuckeryUI.OneAtATime.Enabled) 
                OAAT();

            if (FuckeryUI.InvisibleSabers.Enabled)
                InvisbleSabers();

            if (FuckeryUI.MegaJump.Enabled ||
                FuckeryUI.RandomPositionX.Enabled ||
                FuckeryUI.RandomPositionY.Enabled ||
                FuckeryUI.RandomDirection.Enabled ||
                FuckeryUI.RandomColors.Enabled ||
                FuckeryUI.RandomBombs.Enabled ||
                FuckeryUI.InvisibleSabers.Enabled ||
                FuckeryUI.OneAtATime.Enabled) {

                disableScore = true;
            }

            if (disableScore) {
                ScoreSubmission.DisableSubmission("Nova's Fuckery");
            }
        }

        private static void InvisbleSabers () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<InvisibleSabers>();
        }

        internal static void OAAT () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<OneAtATime>();
        }
    }
}
