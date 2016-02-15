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
            
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            count.PowerupC += 1;
            player.PowerUp[0] = true;
        }
    }
    void RandPowerUp()
    {


    }
    void PowerUpReset()
    {
        player.PowerUp[0] = true;

    }

}
