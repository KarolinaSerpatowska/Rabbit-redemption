using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int hp = 500;
    public int damage = 250000;
    public int pkt = 0;
    Animator animator;
    int rand;


    void Start () {
        animator = GetComponent<Animator>();
        rand = Random.Range(0, 1000);
    }
	
	// Update is called once per frame
	void Update () {
		if(hp <= 0)
        {
            if(rand%2 == 1)
            {
                animator.SetBool("PraiseTheSun", true);
            }
            else
            {
                animator.SetBool("IsDead1", true);
            }
        }
	}
}
