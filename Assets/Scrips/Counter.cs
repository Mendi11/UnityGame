using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {
    [SerializeField]
    private Text mtext;
    [SerializeField]
    private Text mhp;
    // Varibalar
    static Counter minstance = null;
    private int mpowerC = 0;
    private float mdifficult = 1;
    private float mdiffAdd = 0;
    private int mpowerUP;
    private PlayerMovement mplayer;


    // Use this for initialization
    void Awake()
    {
        // Så den gameobjectet förstörs inte.
        if (minstance == null)
        {             
            minstance = this;
        }
        else
            DestroyObject(gameObject);

        // Så den gameobjectet förstörs inte.
        DontDestroyOnLoad(gameObject);
    }
    
    void Start () {
        mplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update() {
        
        // Om man klartat 3 banor så ökar chansen för flera mobs.
        if (mdiffAdd >= 3)
        {
            mdifficult += 1;
            mdiffAdd = 0;
        }
        mplayer.Power = mpowerUP;
        int hps = mplayer.PHealth;
        Debug.Log("Player health is: " + hps);
        // SKriver ut hur många powerup man har tagit;
        mtext.text = "PowerUps: "+ mpowerC;
        mhp.text = "Health: " + hps;
    }

    // Get och set funktioner
    public int PowerupC
    {
        get { return mpowerC; }
        set { mpowerC = value;
            //print(powerC);          
        }
    }
    public float EnemySpawn
    {
        get { return mdifficult;  }
        set { mdifficult = value;  }

    }
    public float Diff
    {
        get { return mdiffAdd; }
        set { mdiffAdd = value; }

    }

    void OnLevelWasLoaded(int level)
    {
        if (level > 0)
            mplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

}
