using UnityEngine;
using System.Collections;

public class EnemyTwo : MonoBehaviour {

    //Variablar
    private int menemyHealth;
    private Rigidbody meRdg;
    private float mrandNrOne, mrandNrTwo, mrandNrThree, mrandNrFour;

    [SerializeField]
    private Rigidbody mbulletRgb;
    private float mtimer = 3;
    private Vector3 mmove;

    // Use this for initialization
    void Start ()
    {
        menemyHealth = 3;
        meRdg = GetComponent<Rigidbody>();
        //Sätter direction åt enemynr2
        mmove = new Vector3(1, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {

        mtimer -= Time.deltaTime;// Kollar tidne.


        if (mtimer <= 0.5f)// Varje 3 sekunder så ska den skjuta ett skott.
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(mbulletRgb, transform.position, transform.rotation);
            Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
            mtimer = 3;
        }
           
            meRdg.velocity = mmove;
        
        
    }

    void RandomNumber()// Randomar ny direction.
    {
        mrandNrOne = Random.Range(-2, -1);
        mrandNrTwo = Random.Range(-2, 2);
        mrandNrThree = Random.Range(0, 2);
        mrandNrFour = Random.Range(-2, 2);
    }

    void OnCollisionEnter (Collision coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            menemyHealth--;

            if (menemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (meRdg.position.x >= 0 && coll.gameObject.tag == "wall")// kollar vilket håll den ska åka. Kollar vart den är i x pos och z pos.
        {
            RandomNumber();
            mmove = new Vector3(mrandNrOne, 0, mrandNrTwo);
        }
        else if (meRdg.position.x <= 0 && coll.gameObject.tag == "wall")
        {
            RandomNumber();
            mmove = new Vector3(mrandNrThree, 0, mrandNrFour);
        }
        else if (meRdg.position.z >= 0 && coll.gameObject.tag == "wall")
        {
            RandomNumber();
            mmove = new Vector3(mrandNrTwo, 0, mrandNrOne);
        }
        else if (meRdg.position.z <= 0 && coll.gameObject.tag == "wall")
        {
            RandomNumber();
            mmove = new Vector3(mrandNrFour, 0, mrandNrThree);
        }
    }
}
