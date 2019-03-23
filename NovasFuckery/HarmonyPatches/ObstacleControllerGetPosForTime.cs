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
    [HarmonyPatch(typeof(ObstacleController))]
    [HarmonyPatch("GetPosForTime")]
    [HarmonyPatch(new Type[] { typeof(float) })]
    class ObstacleControllerGetPosForTime
    {
        static bool Prefix (float time, ref Vector3 __result,
            ref Vector3 ____startPos,
            ref Vector3 ____midPos,
            ref Vector3 ____endPos,
            ref float ____move1Duration,
            ref float ____move2Duration,
            ref PlayerController ____playerController,
            ref bool ____passedAvoidedMarkReported,
            ref float ____passedAvoidedMarkTime,
            ref float ____finishMovementTime,
            ref float ____endDistanceOffest,
            ref float ____startTimeOffset,
            ref ObstacleData ____obstacleData) {

            if (!FuckeryUI.MegaJump.Enabled) return true;
            if (____obstacleData.width > 2) return true;

            Vector3 result;
            if (time < ____move1Duration) {
                result = Vector3.LerpUnclamped(____startPos, ____midPos, time / ____move1Duration);
            } else {
                var fixedStart = ____startPos;
                fixedStart.x /= FuckeryUI.Mirror.Enabled ? -2 : 2;
                fixedStart.y /= 100;

                float t = (time - ____move1Duration) / ____move2Duration;
                float t2 = (time) / (____move1Duration + ____move2Duration);
                result.x = Vector3.Lerp(____midPos, fixedStart, Mathf.SmoothStep(0.0f, 1.0f, t * 4)).x;
                result.y = Vector3.Lerp(____midPos, fixedStart, Mathf.SmoothStep(0.0f, 1.0f, t * 4)).y;
                result.z = ____playerController.MoveTowardsHead(____midPos.z, ____endPos.z, t);
                if (____passedAvoidedMarkReported) {
                    float num = (time - ____passedAvoidedMarkTime) / (____finishMovementTime - ____passedAvoidedMarkTime);
                    num = num * num * num;
                    result.z -= Mathf.LerpUnclamped(0f, ____endDistanceOffest, num);
                }
            }
            __result = result;

            return false;
        }
    }
}
