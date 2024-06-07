using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp;
    public int currentHp = 1000;
    private bool isDead = false;

    [SerializeField] statusBar hpBar;
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
