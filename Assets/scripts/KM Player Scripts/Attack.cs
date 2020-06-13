using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        bool fire = Input.GetButtonDown("Fire1");
        if(fire == true)
        {
            animator.SetTrigger("Attack");
        }
    }
}
