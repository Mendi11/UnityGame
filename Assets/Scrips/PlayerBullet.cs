using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
