using UnityEngine;
using System.Collections;

public class bulletDir : MonoBehaviour {
    Rigidbody bRidg;
    walk player;

	// Use this for initialization
	void Start () {

        bRidg = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

    }
       
    
}
