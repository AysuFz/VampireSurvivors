using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public float timeToAttack = 1f;
    float timer;
    public WeaponStats weaponStats;

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
            timer = timeToAttack;
        }
    }


    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack);
    }

    public abstract void Attack();
}
