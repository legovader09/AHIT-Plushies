using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace AHIT_Plushies
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    public class Weapon : MonoBehaviour
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void Swing(PlayerControllerB instance)
        {
            //if (instance.currentlyHeldObjectServer != null && instance.currentlyHeldObjectServer.itemProperties.itemName == "Umbrella")
        }
    }
}