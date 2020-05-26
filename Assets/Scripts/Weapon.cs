﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject neutralHitFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = .5f;

    PlayerHealth player;
    bool canShoot = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }
    void Update()
    {
        if ((player.isAlive) && (Input.GetMouseButtonDown(0)) && (canShoot))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo();
        }
        
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateNeutralImpactFX(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }

        else { return; }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateNeutralImpactFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(neutralHitFX, hit.point, Quaternion.identity);
        Destroy(impact, .5f);
    }
}
