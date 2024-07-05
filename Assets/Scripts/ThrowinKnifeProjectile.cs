using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    Vector3 direction;
    bool hitDetected = false;
    [SerializeField] float speed = 30;
    public int damage = 3;
    private Vector3 savedDirection;


    public void SetDirection(float dir_x, float dir_y)
    {

        direction = new Vector3(dir_x, dir_y);
        if(dir_x < 0.5f && dir_x >= 0f)
        {
            direction = new Vector3(1f , dir_y);
        }
        if(dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }

    }


    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6 == 0)
        {

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);

            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.takeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
