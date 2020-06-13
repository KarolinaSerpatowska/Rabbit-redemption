using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadController : MonoBehaviour
{

    public float speed;
    public float rotSpeed;
    Rigidbody rb;
    Animator animator;
    Player playerStats;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (playerStats.hp > 0)
        {
            Movement();
            Rotation();
        }
    }

    void Rotation()
    {
        float horizontal = Input.GetAxis("PadHorizontal") * Time.deltaTime;
        Vector3 movement = new Vector3(0.0f, horizontal * rotSpeed, 0.0f);
        if (movement != Vector3.zero)
        {
            transform.Rotate(movement);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Movement()
    {

        float vertical = Input.GetAxis("PadVertical") * Time.deltaTime;
        Vector3 movement = new Vector3(0.0f, 0.0f, vertical * speed);

        if (movement != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
            transform.Translate(movement);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("IsRunning", false);
        }
    }
}
