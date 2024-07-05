using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttacks;

    public WeaponStats(int damage, float timeToAttack, int numberOfAttacks)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttacks = numberOfAttacks;
    }


    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
    }
}

[CreateAssetMenu] public class WeaponData : ScriptableObject
{
    public string name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
