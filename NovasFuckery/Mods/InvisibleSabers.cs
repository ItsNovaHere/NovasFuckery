using System.Collections;
using UnityEngine;

namespace NovasFuckery.Mods
{
    class InvisibleSabers : MonoBehaviour
    {
        void Awake () {
            StartCoroutine(Start());
        }

        IEnumerator Start () {
            yield return new WaitForSeconds(1);

            foreach (Transform t in GetComponent<PlayerController>().leftSaber.gameObject.transform) {
                t.gameObject.SetActive(false);
            }

            foreach (Transform t in GetComponent<PlayerController>().rightSaber.gameObject.transform) {
                t.gameObject.SetActive(false);
            }
        }
    }
}
