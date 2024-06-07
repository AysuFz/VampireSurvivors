using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     Transform targetDestination;
    [SerializeField] float speed;

    GameObject targetGameObject;

    Character targetCharacter;

    Rigidbody2D rgbd2d;

    [SerializeField] int hp = 1;
    [SerializeField] int damage = 1;
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
        rgbd2d.velocity = direction * speed;
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

        targetCharacter.takeDamage(damage);
    }
    public void takeDamage(int damage)
    {
        hp -= damage;

        if(hp < 1)
        {
            deadEnemiesCount++;
            Destroy(gameObject);
        }
    }
}
