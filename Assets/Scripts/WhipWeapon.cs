using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    PlayerMove playerMove;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.takeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }


    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) 
        { 
            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }

        
    }
}
