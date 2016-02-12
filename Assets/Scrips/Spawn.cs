using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    GameObject powerup;
	// Use this for initialization
	void Start () {

     // GameObject.FindGameObjectWithTag("powerup").GetComponent<PowerUp1>();
        
	}
	
	// Update is called once per frame
	void Update () {

        Instantiate(GameObject.FindGameObjectWithTag("powerup").GetComponent<PowerUp1>(), new Vector3(-9.037794f, 0.25f, -7.901674f), new Quaternion(0, 0, 0, 0));
    }
}
