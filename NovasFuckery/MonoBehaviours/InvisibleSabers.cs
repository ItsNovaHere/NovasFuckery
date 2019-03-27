using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Scripting;

namespace NovasFuckery.MonoBehaviours
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
