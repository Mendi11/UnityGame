using UnityEngine;
using System.Collections;

public class bossBulletDir : MonoBehaviour {


    // Variablar
    private Vector3 move;
    private Vector3 vel;
    private Rigidbody bRidg;
    private walk player;
    private Transform playerT;
    private float speed = 8f;
    private Vector3 random;



	// Use this for initialization
	void Start () {
        bRidg = GetComponent<Rigidbody>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;

        // Hämtar spelarens position och normalizerar den så den inte flyger snabbare diagnoalt. 
        move =  playerT.transform.position - transform.position;
        vel = move.normalized;
	}

	
	// Update is called once per frame
	void Update () {

        // rigidbody får vilket håll dne ska flyga gånger speed
        bRidg.velocity = vel * speed;
     
	}
    void OnCollisionEnter(Collision coll)
    {
        // Så länge den inte colliderar med enemy så ska den förstöras.
        if (coll.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
       
    
}
