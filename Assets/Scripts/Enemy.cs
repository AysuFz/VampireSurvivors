using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class EnemyStats
{
    public int hp = 1;
    public int damage = 1;
    public int exp_reward = 400;

    public float speed = 1f;
    private EnemyStats stats;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.exp_reward = stats.exp_reward;
        this.speed = stats.speed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class Enemy : MonoBehaviour,IDamageable
{
     Transform targetDestination;
    

    GameObject targetGameObject;

    Character targetCharacter;

    Rigidbody2D rgbd2d;
    public EnemyStats stats;

    public static int deadEnemiesCount = 0;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    public void setTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * stats.speed;
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }

    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.takeDamage(stats.damage);
    }
    public void takeDamage(int damage)
    {
        stats.hp -= damage;

        if(stats.hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(stats.exp_reward);
            deadEnemiesCount++;
            Destroy(gameObject);
        }
    }

    internal void UpdateStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }
}
