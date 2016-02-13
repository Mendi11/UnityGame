using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    float randomX,randomZ,enemyRand;
    
    //GameObject powerup;
    [SerializeField]
    GameObject powerup;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    private float yvalue;

    // Use this for initialization
    void Start () {

        // GameObject.FindGameObjectWithTag("powerup").GetComponent<PowerUp1>();
        randomX = Random.Range(-14,4);
        randomZ = Random.Range(-14, 4);
        enemyRand =  Random.Range(0, 4);
        Instantiate(powerup, new Vector3(randomX, yvalue, randomZ), new Quaternion(0, 0, 0, 0));
        for (int i = 0; i < enemyRand; i++)
        {
            randomX = Random.Range(-14, 4);
            randomZ = Random.Range(-14, 4);
            Instantiate(enemy, new Vector3(randomX, yvalue, randomZ), new Quaternion(0, 0, 0, 0));

        }

    }
	
	// Update is called once per frame
	void Update () {

        
    }
}
