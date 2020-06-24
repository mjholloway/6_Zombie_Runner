using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int freshAmmo = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, freshAmmo);
            print("Here's some ammo!");
            Destroy(gameObject);
        }
    }
}
