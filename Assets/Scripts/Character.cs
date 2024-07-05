using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp;
    public int currentHp = 1000;
    private bool isDead = false;
    public float hpRegenerationRate = 50f;
    public float hpRegenerationTimer;
    public float damageBonus;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    [SerializeField] statusBar hpBar;
    [SerializeField] DataContainer dataContainer;


    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }


    private void Start()
    {
        LoadSelectedCharacter(dataContainer.selectedCharacter);

        ApplyPersistentUpgrades();

        hpBar.SetState(currentHp, maxHp);
    }


    private void ApplyPersistentUpgrades()
    {
        int hpUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.HP);
        maxHp += maxHp / 10 * hpUpgradeLevel;

        int damageUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.Damage);
        damageBonus = 1f + 0.1f * damageUpgradeLevel;
    }


    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        if (hpRegenerationTimer > 1f) 
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }


    private void LoadSelectedCharacter(CharacterData selectedCharacter)
    {
        InitAnimation(selectedCharacter.spritePrefab);
        GetComponent<WeaponManager>().AddWeapon(selectedCharacter.startingWeapon);
    }


    private void InitAnimation(GameObject spritePrefab)
    {
       GameObject animeObject = Instantiate(spritePrefab, transform);
        GetComponent<Animate2>().SetAnimate(animeObject);
    }


    public void takeDamage(int damage)
    {
        if(isDead == true)
        {
            return;
        }
        currentHp -= damage;

        if(currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(int amount)
    {
        if(currentHp <= 0)
        {
            return;
        }
        currentHp += amount;

        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        hpBar.SetState(currentHp, maxHp);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            takeDamage(100);
        } else if (other.gameObject.CompareTag("Chah"))
        {
            takeDamage(1000);
        }
    }
}
