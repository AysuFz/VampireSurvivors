using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);

        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUpgradeIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }
}
