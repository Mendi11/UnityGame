using UnityEngine;
using System.Collections;

public class PowerUp1 : MonoBehaviour {


    float timer = 9999999;
    //[SerializeField]
    walk player;
   [SerializeField]
    Counter count;

    // Use this for initialization
    void Awake()
    {
        count = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();


    }
    void Start () {
  
	
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            //print(timer);
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
            count.PowerupC += 1;
            transform.position = new Vector3(1000,1000,1000);
            timer = 10;
        }
        player.PowerUp[0] = true;

    }
}
