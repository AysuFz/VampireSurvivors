using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate2 : MonoBehaviour
{
    Animator animator;
    public float horizontal;
    private void Update()
    {
        animator.SetFloat("Horizontal", horizontal);
    }

    internal void SetAnimate(GameObject animObject)
    {
        animator = animObject.GetComponent<Animator>();

    }
}
