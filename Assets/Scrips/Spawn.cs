using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    //variablar.
    float randomX,randomZ,enemyRand,enemyTwoRand;
    
    
    //hämtar GameObject;
    [SerializeField]
    GameObject powerup;
    [SerializeField]
    GameObject enemyOne;
    [SerializeField]
    GameObject enemyTwo;
    [SerializeField]
    GameObject enemyThree;
    [SerializeField]
    GameObject enemyFour;
    [SerializeField]
    private float yvalue;
   
    Counter diff;


    // Use this for initialization

    void Awake()
    {
        diff = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
      

    }

    void Start () {
      //Spawnar powerup cuben.
        Instantiate(powerup, new Vector3(PosRandom(-14, 4), yvalue, PosRandom(-14, 4)), new Quaternion(0, 0, 0, 0));
        //Spawnar enemmy nr1 och  nr2 spawnar mera beroende på diff.
        EnemySpawn(PosRandom(0, diff.EnemySpawn), enemyOne, 0.77f);
        EnemySpawn(PosRandom(0,diff.EnemySpawn), enemyTwo, 1.289f);
        EnemySpawn(PosRandom(0, diff.EnemySpawn - 2), enemyThree, -1.94f);
        EnemySpawn(PosRandom(0, diff.EnemySpawn - 4), enemyFour, 2.63f);
        diff.Diff += 1;
    }
    //Hämtar float vaiabel och object variabel.
    void EnemySpawn(float eRand,GameObject obj,float y)
    {
        // Randomar hur många looper den ska göra.
        for (int i = 0; i < eRand; i++)
        {      
            // Spawnar object mer random pos.
            Instantiate(obj, new Vector3(PosRandom(-14,4), y, PosRandom(-14, 4)), new Quaternion(0, 0, 0, 0));
            
        }
    }

    // Hämtar in 2 float variablar och returnar 1 float variabel.
    float PosRandom(float randOne, float randTwo)
    {
        float randPos = Random.Range(randOne,randTwo);
        return randPos;
    }

	// Update is called once per frame
	void Update () {

        
    }
}
