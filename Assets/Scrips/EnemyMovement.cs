using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    /*[Range(0.0F, 10.0F)]*/
    private float menemySpeed = 4;
    /*[Range(0, 10)]*/
    private int menemyHealth = 3;
    Transform mtarget;
    Rigidbody meneRig;




    // Use this for initialization
    void Start()
    {
        meneRig = GetComponent<Rigidbody>();
        mtarget = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //Förljer spelaren.
        if (mtarget == null)
            return;
        Vector3 move = mtarget.position - transform.position;
        Vector3 vel = meneRig.velocity;
        vel = move.normalized;
        meneRig.velocity = vel * menemySpeed;

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            menemyHealth--;
            if (menemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

