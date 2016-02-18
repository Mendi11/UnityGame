using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    //variablar.
    float randomX,randomZ,enemyRand,enemyTwoRand;
    private bool enemies;
    private int spawnCheck = 1;





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
    GameObject capsule;
    [SerializeField]
    private float yvalue;
    Counter diff;


    // Use this for initialization

    void Awake()
    {
        //capsule = GameObject.FindGameObjectWithTag("level");
        diff = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
        


}

    void Start() {
       
        //Spawnar powerup cuben.
        Instantiate(powerup, new Vector3(PosRandom(-14, 4), yvalue, PosRandom(-14, 4)), new Quaternion(0, 0, 0, 0));
        //Spawnar enemmy nr1 och  nr2 spawnar mera beroende på diff.
        EnemySpawn(PosRandom(0, diff.EnemySpawn), enemyOne, 0.77f);
        EnemySpawn(PosRandom(0,diff.EnemySpawn), enemyTwo, 1.289f);
        EnemySpawn(PosRandom(0, diff.EnemySpawn -3), enemyThree, -1.94f);
        EnemySpawn(PosRandom(0, diff.EnemySpawn - 4), enemyFour, 2.63f);
        diff.Diff += 2;

        
}
    //Hämtar float vaiabel och object variabel.
    void EnemySpawn(float eRand,GameObject obj,float y)
    {
        float ys = 1.44f;
        if (obj == enemyThree)
        {
            ys = -2.6f;
        }
        else if (obj == enemyFour)
        {
            ys = 1.5f;
        }
        else
        {
            ys = 1.44f;

        }

        Vector3[] spawnP = new Vector3[4];
        spawnP[0] = new Vector3(10f, ys, -13f);
        spawnP[1] = new Vector3(-22f, ys, -13f);
        spawnP[2] = new Vector3(10f, ys, 1.7f);
        spawnP[3] = new Vector3(-21.7f, ys, 1.69f);

        // Randomar hur många looper den ska göra.
        for (int i = 0; i < eRand; i++)
        {
           
            // Spawnar object mer random pos.
            Instantiate(obj, spawnP[Random.Range(0,3)], new Quaternion(0, 0, 0, 0));
            
        }
    }

    // Hämtar in 2 float variablar och returnar 1 float variabel.
    float PosRandom(float randOne, float randTwo)
    {
        float randPos = Random.Range(randOne,randTwo);
        return randPos;
    }

	// Update is called once per frame
	void Update (){
        //Check if all eneies are dead. IF THEY ARE SPAWN Capsule
        enemies = GameObject.FindGameObjectWithTag("Enemy");
        if (enemies == false && spawnCheck == 1)
        {
            spawnCheck = 0;
            Instantiate(capsule, new Vector3(-6.07f, 0.145f, 3.34f), new Quaternion(0, 0, 0, 0));
        }

}
}
