using UnityEngine;
using System.Collections;

public class EnemyTwo : MonoBehaviour {

    //Variablar
    private Rigidbody eRdg;
    private float randNrOne, randNrTwo, randNrThree, randNrFour;

    [SerializeField]
    private Rigidbody bulletRgb;
    private float timer = 3;
    private Vector3 move;

    // Use this for initialization
    void Start () {

        eRdg = GetComponent<Rigidbody>();
        //Sätter direction åt enemynr2
        move = new Vector3(1, 0, 1);

    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;// Kollar tidne.


        if (timer <= 0.5f)// Varje 3 sekunder så ska den skjuta ett skott.
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRgb, transform.position, transform.rotation);
            Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
            timer = 3;
        }
      

        if (eRdg.position.x >= 4)// kollar vilket håll den ska åka. Kollar vart den är i x pos och z pos.
        {
            RandomNumber();
            move = new Vector3(randNrOne, 0, randNrTwo);
        }
        else if (eRdg.position.x <= -14)
        {
            RandomNumber();
            move = new Vector3(randNrThree, 0, randNrFour);
        }
        else if (eRdg.position.z >= 4)
        {
            RandomNumber();
            move = new Vector3(randNrTwo, 0, randNrOne);
        }
        else if (eRdg.position.z <= -14)
        {
            RandomNumber();
            move = new Vector3(randNrFour, 0, randNrThree);
        }
       
            eRdg.velocity = move;
        
        
    }

    void RandomNumber()// Randomar ny direction.
    {
        randNrOne = Random.Range(-2, -1);
        randNrTwo = Random.Range(-2, 2);
        randNrThree = Random.Range(0, 2);
        randNrFour = Random.Range(-2, 2);
    }

}
