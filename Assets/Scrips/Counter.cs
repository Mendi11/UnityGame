using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {
    [SerializeField]
    Text text;
    bool created = true;
    static Counter instance = null;
    private int powerC = 0;

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
        
    }
	
	// Update is called once per frame
	void Update () {
       // string temp = powerC.ToString();
        text.text = "PowerUps: "+ powerC;
    }
    public int PowerupC
    {
        get { return powerC; }
        set { powerC = value;
            print(powerC);
           
        }
    }
}
