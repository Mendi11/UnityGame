using UnityEngine;
using System.Collections;

public class PowerUp1 : MonoBehaviour {


    float timer = 100000;
    //[SerializeField]
    walk player;

	// Use this for initialization
	void Start () {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();
	
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            print(timer);
        }
        else // timer is <= 0
        {
            print("TIME OVER\nPress X to restart");

        }
        if (timer <= 0.5)
        {
            player.PowerUp[0] = false;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            transform.position = new Vector3(100,1000,1000);
            timer = 10;

        }
        player.PowerUp[0] = true;

    }
}
