using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 MovmentVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [SerializeField] float speed = 3f;
    private float originalSpeed;
    [SerializeField] public float slowDownFactor = 0.5f;
    Animate2 animate2;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        MovmentVector = new Vector3();
        animate2 = GetComponent<Animate2>();
        originalSpeed = speed;
    }

    void Update()
    {
        MovmentVector.x = Input.GetAxis("Horizontal");
        MovmentVector.y = Input.GetAxis("Vertical");

        if (MovmentVector.x != 0)
        {
            lastHorizontalVector = MovmentVector.x;
        }
        if (MovmentVector.y != 0)
        {
            lastVerticalVector = MovmentVector.y;
        }

        animate2.horizontal = MovmentVector.x;
        MovmentVector *= speed;
        rgbd2d.velocity = MovmentVector;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skeleton"))
        {
            speed *= slowDownFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skeleton"))
        {
            speed = originalSpeed;
        }
    }
}