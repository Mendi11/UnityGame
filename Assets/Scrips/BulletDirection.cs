using UnityEngine;
using System.Collections;

public class BulletDirection : MonoBehaviour
{


    // Variablar
    private Vector3 mmove;
    private Vector3 mvel;
    private Rigidbody mbRidg;
    private PlayerMovement mplayer;
    private Transform mplayerT;
    private float mspeed = 8f;



    // Use this for initialization
    void Start()
    {
        mbRidg = GetComponent<Rigidbody>();
        mplayerT = GameObject.FindGameObjectWithTag("Player").transform;

        // Hämtar spelarens position och normalizerar den så den inte flyger snabbare diagnoalt. 
        mmove = mplayerT.transform.position - transform.position;
        mvel = mmove.normalized;
    }


    // Update is called once per frame
    void Update()
    {

        // rigidbody får vilket håll dne ska flyga gånger speed
        mbRidg.velocity = mvel * mspeed;

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
