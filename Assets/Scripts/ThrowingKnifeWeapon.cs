using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float spread = 0.5f;
    PlayerMove playerMove;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    public override void Attack()
    {
        

        for (int i = 0; i < weaponStats.numberOfAttacks; i++) 
        {
            GameObject thrownKnife = Instantiate(knifePrefab);

            Vector3 newKnifePosition = transform.position;

            if (weaponStats.numberOfAttacks > 1)
            {
                newKnifePosition.y -= (spread * (weaponStats.numberOfAttacks - 1)) / 2;
                newKnifePosition.y += i * spread;
            }

            thrownKnife.transform.position = newKnifePosition;
            ThrowingKnifeProjectile throwingDaggerProjectile = thrownKnife.GetComponent<ThrowingKnifeProjectile>();
        
            throwingDaggerProjectile.SetDirection(playerMove.lastHorizontalVector, 0f);
            throwingDaggerProjectile.damage = weaponStats.damage;
        }

        
    }
}
