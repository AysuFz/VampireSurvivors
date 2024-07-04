using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class WeaponStats
{
    public int damage;
    public float timeToAttack;

    public WeaponStats(int damage, float timeToAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
    }
}

[CreateAssetMenu] public class WeaponData : ScriptableObject
{
    public string name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
