using UnityEngine;
using System.Collections;

public class bulletDir : MonoBehaviour {

    Vector3 move;
    Vector3 vel;

    
    Rigidbody bRidg;

    walk player;

    Transform playerT;
    float speed = 8f;

	// Use this for initialization
	void Start () {
        bRidg = GetComponent<Rigidbody>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        move =  playerT.transform.position - transform.position;
        vel = move.normalized;
	}

	
	// Update is called once per frame
	void Update () {
        bRidg.velocity = vel * speed;

	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }

    }
       
    
}
