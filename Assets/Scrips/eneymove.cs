﻿using UnityEngine;
using System.Collections;

public class eneymove : MonoBehaviour {
    /*[Range(0.0F, 10.0F)]*/ private float enemySpeed = 2;
    /*[Range(0, 10)]*/ private int enemyHealth = 3;
    Transform target;
    Rigidbody eneRig;




	// Use this for initialization
	void Start () {
        eneRig = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = target.position - transform.position;
        Vector3 vel = eneRig.velocity;
        vel = move.normalized;
        eneRig.velocity = vel * enemySpeed;
        // transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            enemyHealth--;
            if (enemyHealth <= 0)    // if(boom.gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }
        }
    }
}

    