using UnityEngine;
using System.Collections;

public class eneymove : MonoBehaviour {
    Transform target;
    Rigidbody eneRig;

	// Use this for initialization
	void Start () {
        eneRig = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = target.position - transform.position;
        Vector3 vel = eneRig.velocity;
        vel = move.normalized;
        eneRig.velocity = vel * 3f;

       // transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
    }
}
