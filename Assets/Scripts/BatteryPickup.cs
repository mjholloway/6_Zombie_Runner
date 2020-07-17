using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            FlashlightSystem flashlight = FindObjectOfType<FlashlightSystem>();
            flashlight.RestoreLightAngle(50f);
            flashlight.RestoreLightIntensity(4f);
            Destroy(gameObject);
        }
    }
}
