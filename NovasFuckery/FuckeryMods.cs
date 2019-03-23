using BS_Utils.Gameplay;
using NovasFuckery.MonoBehaviours;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NovasFuckery
{
    class FuckeryMods
    {
        internal static void SetupMods () {
            bool disableScore = false;

            if (FuckeryUI.OneAtATime.Enabled) {
                OAAT();
                disableScore = true;
            }

            if (FuckeryUI.MegaJump.Enabled || 
                FuckeryUI.MildAnnoyance.Enabled || 
                FuckeryUI.RandomPosition.Enabled) {

                disableScore = true;
            }

            if (disableScore) {
                ScoreSubmission.DisableSubmission("Nova's Fuckery");
            }
        }

        //One At A Time
        internal static void OAAT () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<OneAtATime>();
        }
    }
}
