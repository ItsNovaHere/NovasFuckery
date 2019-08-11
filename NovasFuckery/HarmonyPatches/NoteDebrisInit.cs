using Harmony;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteDebris))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class NoteDebrisInit
    {
        static void Prefix(NoteType noteType, Transform initTransform, Vector3 cutPoint, Vector3 cutNormal, Vector3 force, Vector3 torque, ref float lifeTime) {
            if(FuckeryUI.UnlimitedDebris.Enabled) lifeTime = 125f;
        }

        static void Postfix(NoteType noteType, Transform initTransform, Vector3 cutPoint, Vector3 cutNormal, Vector3 force, Vector3 torque, float lifeTime, ref Rigidbody ____rigidbody) {
            if (FuckeryUI.UnlimitedDebris.Enabled) ____rigidbody.useGravity = false;
        }
    }
}
