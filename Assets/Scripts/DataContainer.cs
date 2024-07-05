using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerPersistentUpgrades
{
    HP,
    Damage
}



[Serializable]
public class PlayerUpgrades
{
    public PlayerPersistentUpgrades persistentUpgrades;
    public int level = 0;
    public int costToUpgrade = 100;
}



[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;
    public List<PlayerUpgrades> upgrades;
}
