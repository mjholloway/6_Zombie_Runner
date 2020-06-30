using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool hasDied = false;

    public void TakeDamage(float damage)
    {
        if (hasDied) { return; }
        EnemyAI enemy = GetComponent<EnemyAI>();
        enemy.OnDamageTaken();
        hitPoints -= damage;
        if (hitPoints <= 0f)
        {
            enemy.OnDeath();
            hasDied = true;
        }
    }
}
