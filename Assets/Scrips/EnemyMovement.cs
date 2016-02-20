﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    /*[Range(0.0F, 10.0F)]*/
    private float enemySpeed = 4;
    /*[Range(0, 10)]*/
    private int enemyHealth = 3;
    Transform target;
    Rigidbody eneRig;




    // Use this for initialization
    void Start()
    {
        eneRig = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //Förljer spelaren.
        if (target == null)
            return;
        Vector3 move = target.position - transform.position;
        Vector3 vel = eneRig.velocity;
        vel = move.normalized;
        eneRig.velocity = vel * enemySpeed;

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
