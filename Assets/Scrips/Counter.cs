using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text hp;
    // Varibalar
    static Counter instance = null;
    private int powerC = 0;
    private float difficult = 1;
    private float diffAdd = 0;
    private int powerUP;
    private walk player;


    // Use this for initialization
    void Awake()
    {
        // Så den gameobjectet förstörs inte.
        if (instance == null)
        {             
            instance = this;
        }
        else
            DestroyObject(gameObject);

        // Så den gameobjectet förstörs inte.
        DontDestroyOnLoad(gameObject);
    }
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();
        
    }

    // Update is called once per frame
    void Update() {
        
        // Om man klartat 3 banor så ökar chansen för flera mobs.
        if (diffAdd >= 3)
        {
            difficult += 1;
            diffAdd = 0;
        }
        player.Power = powerUP;
        int hps = player.PHealth;
        Debug.Log("Player health is: " + hps);
        // SKriver ut hur många powerup man har tagit;
        text.text = "PowerUps: "+ powerC;
        hp.text = "Health: " + hps;
    }

    // Get och set funktioner
    public int PowerupC
    {
        get { return powerC; }
        set { powerC = value;
            //print(powerC);          
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

    void OnLevelWasLoaded(int level)
    {
        if (level > 0)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();
    }

}
