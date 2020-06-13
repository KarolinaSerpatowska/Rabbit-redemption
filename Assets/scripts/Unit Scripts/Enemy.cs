using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;
    GameObject[] players;
    ParticleSystem part;
    Rigidbody rb;

    Player[] playersStats;

    //Rabbit stats
    public int hp = 200;
    public int speed = 5;
    public int damage = 40;
    public float dis = 20;
    public int pointsToAdd = 20; //when rabbit is dead

    public float attackDeley = 2;
    float timeOfLastAttack = 0;

    bool isDead = false; //I'm dead?
    string playerWhoKillMe = "";

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
        FillPlayerStats();
        rb = GetComponent<Rigidbody>();
        part = GetComponentInChildren<ParticleSystem>();
    }

    void FillPlayerStats()
    {
        playersStats = new Player[players.Length];
        for (int i = 0; i < players.Length; ++i)
        {
            playersStats[i] = players[i].GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp > 0) Move();
        else Die();
    }

    private void Die()
    {
        if (isDead == false)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsDead", true);
            animator.SetBool("IsBiting", false);
            part.Stop();
            AddPoints();
            Destroy(gameObject, 5);
            isDead = true;
        }
    }

    private void AddPoints()
    {
        if (players[0].name == playerWhoKillMe)
            playersStats[0].pkt += pointsToAdd;
        else
            playersStats[1].pkt += pointsToAdd;
    }

    private void Move()
    {
        GameObject player = GetClosestAlivePlayer();
        transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        rb.velocity = Vector3.zero;

        if (distance > dis)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsBiting", false);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsBiting", true);
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SwordGamepad" || other.tag == "SwordKeyboard")
        {
            Destroy(other.gameObject);
            hp -= playersStats[0].damage;
            playerWhoKillMe = "Paladin" + other.tag.Substring(5);
        }
    }

    GameObject GetClosestAlivePlayer()
    {
        if (playersStats[0].hp <= 0) return players[1];
        else if (playersStats[1].hp <= 0) return players[0];
        float distance1 = Vector3.Distance(players[0].transform.position, transform.position);
        float distance2 = Vector3.Distance(players[1].transform.position, transform.position);
        return (distance1 > distance2) ? players[1] : players[0];
    }

    void Attack()
    {
        if (timeOfLastAttack + attackDeley < Time.time)
        {
            GetClosestAlivePlayer().GetComponent<Player>().hp -= damage;
            timeOfLastAttack = Time.time;
        }
    }

}
