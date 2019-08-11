using BS_Utils.Utilities;
using UnityEngine;
using SaberType = Saber.SaberType;

namespace NovasFuckery.Mods
{

    internal class OneAtATime : MonoBehaviour
    {
        private PlayerController _player;
        private VRController _controllerL;
        private VRController _controllerR;

        private void Start () {
            _player = GetComponent<PlayerController>();
            _player.rightSaber.gameObject.SetActive(false);

            _controllerL = (VRController) _player.leftSaber.GetField("_vrController");
            _controllerR = (VRController) _player.rightSaber.GetField("_vrController");
        }

        private void Update () {
            if (_controllerL.triggerValue > .5f && _controllerR.triggerValue > .5f) return;

            if (_controllerL.triggerValue > .5f) {
                ActivateSaber(SaberType.SaberA);
            } else if(_controllerR.triggerValue > .5f) {
                ActivateSaber(SaberType.SaberB);
            }
        }

        private void ActivateSaber(SaberType saberType) {
            if(saberType == SaberType.SaberA) {
                if (_player.rightSaber.gameObject.activeSelf) {
                    _player.leftSaber.gameObject.SetActive(true);
                    _player.rightSaber.gameObject.SetActive(false);
                }
            } else if(saberType == SaberType.SaberB) {
                if (_player.leftSaber.gameObject.activeSelf) {
                    _player.rightSaber.gameObject.SetActive(true);
                    _player.leftSaber.gameObject.SetActive(false);
                }
            }
        }

        private static SaberType GetOpposite(SaberType saberType) {
            if (saberType == SaberType.SaberA)
                return SaberType.SaberB;

            return SaberType.SaberA;
        }
    }
}
