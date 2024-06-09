using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour , IDamageable
{
    public void takeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
