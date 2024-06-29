using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class WeaponStats
{
    public int damage;
    public float timeToAttack;
}

[CreateAssetMenu] public class WeaponData : ScriptableObject
{
    public string name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
}
