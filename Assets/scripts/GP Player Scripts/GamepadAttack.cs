using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadAttack : MonoBehaviour {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        bool fire = Input.GetButtonDown("PadFire");
        if (fire == true)
        {
            animator.SetTrigger("Attack");
        }
    }
}
