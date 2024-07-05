using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    float timer;
    public WeaponStats weaponStats;

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }


    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.numberOfAttacks);
    }

    //public virtual void PostDamage(int Damage, Vector3 targetPosition)
    //{
    //    MessageSystem.instance.PostMessage(Damage.ToString(), targetPosition);
    //}

    public abstract void Attack();

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }

}
