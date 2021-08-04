using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isAlive = true;

    [SerializeField] float playerHealth = 100f;
    [SerializeField] BloodSplatter blood;

    public void TakeDamage(float damage)
    {
        blood.DisplayBlood();
        playerHealth -= damage;
        if (playerHealth <= 0f)
        {
            GetComponent<DeathHandler>().HandleDeath();
            isAlive = false;
        }
    }
}
