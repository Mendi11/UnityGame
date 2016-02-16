using UnityEngine;
using System.Collections;

public class PowerUp1 : MonoBehaviour {

    private walk player;
    private Counter count;

    // Use this for initialization
    void Awake()
    {
        //Hämtar instancen av gameobjet
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
            RandPowerUp();
        }
    }
    void RandPowerUp()
    {
        // Randomen lägs vilken power up man får.
       player.PowerUp[PowerUpReset()] = true;

    }
    int PowerUpReset()
    {
        //Sätter alla False och retunar en ny random;
        int randD = Random.Range(0,5);
        player.PowerUp[0] = false;
        player.PowerUp[1] = false;
        player.PowerUp[2] = false;
        player.PowerUp[3] = false;
        player.PowerUp[4] = false;

        return randD ;
    }

}
