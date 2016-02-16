using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {
    [SerializeField]
    Text text;
    //bool created = true;
    static Counter instance = null;
    private int powerC = 0;
    private float difficult = 2;
    private float diffAdd = 0;
    private int powerUP;
    walk player;


    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {             
            instance = this;
        }
        else
            DestroyObject(gameObject);


        DontDestroyOnLoad(gameObject);
    }
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();
        
    }
	
	// Update is called once per frame
	void Update () {
        // string temp = powerC.ToString();
        if (diffAdd >= 3)
        {
            difficult += 1;
            diffAdd = 0;
        }
       player.Power  = powerUP;


        text.text = "PowerUps: "+ powerC;
    }
    public int PowerupC
    {
        get { return powerC; }
        set { powerC = value;
            print(powerC);          
        }
    }
    public float EnemySpawn
    {
        get { return difficult;  }
        set { difficult = value;  }

    }
    public float Diff
    {
        get { return diffAdd; }
        set { diffAdd = value; }

    }

}
