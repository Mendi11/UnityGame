using UnityEngine;
using System.Collections;

public class PowerUp1 : MonoBehaviour {

    private PlayerMovement mplayer;
    private Counter mcount;

    // Use this for initialization
    void Awake()
    {
        //Hämtar instancen av gameobjet
        mcount = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
        mplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();


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
            mcount.PowerupC += 1;
            RandPowerUp();
            if (Application.loadedLevel == 4)
            {
                Instantiate(gameObject, new Vector3(Random.Range(-10,4), 1, Random.Range(-10, 4)), new Quaternion(0, 0, 0, 0));

            }
        }
    }
    void RandPowerUp()
    {
        // Randomen lägs vilken power up man får.
       mplayer.PowerUp[PowerUpReset()] = true;

    }
    int PowerUpReset()
    {
        //Sätter alla False och retunar en ny random;
        int randD = Random.Range(0,5);
        mplayer.PowerUp[0] = false;
        mplayer.PowerUp[1] = false;
        mplayer.PowerUp[2] = false;
        mplayer.PowerUp[3] = false;
        mplayer.PowerUp[4] = false;

        return randD ;
    }

}
