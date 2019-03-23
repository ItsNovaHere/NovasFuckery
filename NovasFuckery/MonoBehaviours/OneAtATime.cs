using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using BS_Utils.Utilities;
using Button = OVRInput.Button;
using SaberType = Saber.SaberType;

namespace NovasFuckery.MonoBehaviours
{
    class OneAtATime : MonoBehaviour
    {
        PlayerController player;
        VRController controllerL;
        VRController controllerR;

        void Start () {
            player = GetComponent<PlayerController>();
            player.rightSaber.gameObject.SetActive(false);

            controllerL = (VRController) player.leftSaber.GetField("_vrController");
            controllerR = (VRController) player.rightSaber.GetField("_vrController");
        }

        void Update () {
            if (controllerL.triggerValue > .5f && controllerR.triggerValue > .5f) return;

            if (controllerL.triggerValue > .5f) {
                if (player.rightSaber.gameObject.activeSelf) {
                    player.leftSaber.gameObject.SetActive(true);
                    player.rightSaber.gameObject.SetActive(false);
                }
            } else if(controllerR.triggerValue > .5f) {
                if (player.leftSaber.gameObject.activeSelf) {
                    player.rightSaber.gameObject.SetActive(true);
                    player.leftSaber.gameObject.SetActive(false);
                }
            }
        }

        static SaberType GetOpposite(SaberType saberType) {
            if (saberType == SaberType.SaberA)
                return SaberType.SaberB;

            return SaberType.SaberA;
        }
    }
}
