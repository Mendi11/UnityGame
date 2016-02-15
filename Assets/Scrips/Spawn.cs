using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    float randomX,randomZ,enemyRand,enemyTwoRand;
    
    
    //GameObject powerup;
    [SerializeField]
    GameObject powerup;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject enemyTwo;
    [SerializeField]
    private float yvalue;
   
    Counter diff;


    // Use this for initialization

    void Awake()
    {
        diff = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();

    }

    void Start () {
      
        Instantiate(powerup, new Vector3(PosRandom(-14, 4), yvalue, PosRandom(-14, 4)), new Quaternion(0, 0, 0, 0));
        EnemySpawn(PosRandom(0, diff.EnemySpawn), enemy);
        EnemySpawn(PosRandom(0,diff.EnemySpawn), enemyTwo);
        diff.Diff += 1;
    }

    void EnemySpawn(float eRand,GameObject obj)
    {
        for (int i = 0; i < eRand; i++)
        {     
            Instantiate(obj, new Vector3(PosRandom(-14,4), 1.057f, PosRandom(-14, 4)), new Quaternion(0, 0, 0, 0));
        }
    }
    float PosRandom(float randOne, float randTwo)
    {
        float randPos = Random.Range(randOne,randTwo);
        return randPos;
    }

	// Update is called once per frame
	void Update () {

        
    }
}
