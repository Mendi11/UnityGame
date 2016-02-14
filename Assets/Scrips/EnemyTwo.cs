using UnityEngine;
using System.Collections;

public class EnemyTwo : MonoBehaviour {

    Rigidbody eRdg;
    float randNrOne, randNrTwo, randNrThree, randNrFour;

    [SerializeField]
    Rigidbody bulletRgb;

    float timer = 3;

    Vector3 move;

    // Use this for initialization
    void Start () {

        eRdg = GetComponent<Rigidbody>();
        //RandomNumber();
        //randNrOne = 1;s
        //randNrTwo = 1;
        move = new Vector3(1, 0, 1);

    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;


        if (timer <= 0.5f)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRgb, transform.position, transform.rotation);
            Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
            timer = 3;
        }
      

        if (eRdg.position.x >= 4)
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

    void RandomNumber()
    {
        randNrOne = Random.Range(-2, -1);
        randNrTwo = Random.Range(-2, 2);
        randNrThree = Random.Range(0, 2);
        randNrFour = Random.Range(-2, 2);
    }

}
