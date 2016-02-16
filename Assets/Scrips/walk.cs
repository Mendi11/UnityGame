using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {

    private int randomNumber;
    Rigidbody rgb;
    [SerializeField]
    Rigidbody bulletRgb;
    // bool right = true;
    float bulletSpeed = 15f;
    int powerr = 3;
    [SerializeField]
    Counter count;


    bool[] powerUps = new bool[5];
    // Use this for initialization
    void Awake()
    {
        count = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();

    }

    void Start() {
        rgb = GetComponent<Rigidbody>();
        //bulletRgb = GameObject.FindGameObjectWithTag("bullet").GetComponent<Rigidbody>();
        
        PowerUpStart();

    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(h, 0, v);

        Vector3 vel = rgb.velocity;
        vel = movement.normalized;
        rgb.velocity = vel * 4f;

    }

    void OnCollisionEnter(Collision coll) {
        randomNumber = Random.Range(2, 5);

        if (coll.gameObject.tag == "level")
        {
           
            UnityEngine.SceneManagement.SceneManager.LoadScene(randomNumber);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerUps[0] == true)
            {
                BulletShot(-1f, transform.right);

            }
            else if (powerUps[1] == true)
            {
                BulletShot(1f, transform.forward);
            }
            else if (powerUps[2] == true)
            {
                BulletShot(-1f, transform.right);
                BulletShot(1f, transform.right);
            }
            else if (powerUps[3] == true)
            {
                BulletShot(1f, transform.forward - transform.right);
                BulletShot(1f, transform.forward + transform.right);
            }
            else if (powerUps[4] == true)
            {
                BulletShot(-1f, transform.right);
                BulletShot(1f, transform.right);
                BulletShot(1f, transform.forward - transform.right);
                BulletShot(1f, transform.forward + transform.right);
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (powerUps[0] == true)
            {
                BulletShot(1f, transform.right);
                
            }
            else if (powerUps[1] == true)
            {
                BulletShot(-1f, transform.forward);
            }
            else if (powerUps[2] == true)
            {
                BulletShot(-1f, transform.forward);
                BulletShot(1f, transform.forward);
            }
            else if (powerUps[3] == true)
            {
                BulletShot(-1f, transform.forward - transform.right);
                BulletShot(-1f, transform.forward + transform.right);
            }
            else if (powerUps[4] == true)
            {
                BulletShot(-1f, transform.forward);
                BulletShot(1f, transform.forward);
                BulletShot(-1f, transform.forward - transform.right);
                BulletShot(-1f, transform.forward + transform.right);
            }
        }
      }
    void PowerUpStart()
    {
        powerUps[0] = false;
        powerUps[1] = false;
        powerUps[2] = false;
        powerUps[3] = false;
        powerUps[4] = false;

    }
   void BulletShot(float dir ,Vector3 transfom)
    {
        //print(transform.right);
        Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRgb, transform.position, transform.rotation);
        bulletClone.velocity = transfom * dir * bulletSpeed;
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
    }
 
    public bool[] PowerUp
    {
        get { return powerUps; }
        set { powerUps = value; }


    }
    public int Power
    {
        get { return powerr; }
        set { powerr = value; }

    }
}
