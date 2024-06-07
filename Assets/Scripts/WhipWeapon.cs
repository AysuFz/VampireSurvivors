using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{

   [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;

    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

    [SerializeField] int whipDamage = 1;

    PlayerMove playerMove;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if(playerMove.lastHorizontalVector > 0)
        {
            rightWhip.SetActive(true);
            Collider2D[] colliders =  Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().takeDamage(whipDamage);
            }
        }
    }
}
