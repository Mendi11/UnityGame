using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private int mplayerHealth;
    private int mrandomNumber;
    private Rigidbody mrgb;
    [SerializeField]
    private Rigidbody mbulletRgb;
    private float mbulletSpeed = 15f;
    private int mpowerr = 3;
    [SerializeField]
    
    private Counter diff;


    bool[] mpowerUps = new bool[5];
    // Use this for initialization
    void Awake()
    {
      
        diff = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
    }

    void Start()
    {

        mplayerHealth = 3;
        mrgb = GetComponent<Rigidbody>();
        //bulletRgb = GameObject.FindGameObjectWithTag("bullet").GetComponent<Rigidbody>();

        PowerUpStart();
        mpowerUps[0] = true;

    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(h, 0, v);

        Vector3 vel = mrgb.velocity;
        vel = movement.normalized;
        mrgb.velocity = vel * 5f;

    }

    void OnCollisionEnter(Collision coll)
    {


        if (coll.gameObject.tag == "level")
        {

            int i = 4;
            if (diff.EnemySpawn >= 4)
            {
                i = 5;
            }

            mrandomNumber = Random.Range(2, i);
            UnityEngine.SceneManagement.SceneManager.LoadScene(mrandomNumber);
        }

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "eBullet")
        {
            mplayerHealth--;
            Debug.Log("Hit by something, health:" + mplayerHealth);

            if (mplayerHealth <= 0)
            {
                //Destroy(gameObject);
                //playerHealth = 3;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);


        // Skjuter olika skott
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (mpowerUps[0] == true)
            {
                BulletShot(-1f, transform.right);

            }
            else if (mpowerUps[1] == true)
            {
                BulletShot(1f, transform.forward);
            }
            else if (mpowerUps[2] == true)
            {
                BulletShot(-1f, transform.right);
                BulletShot(1f, transform.right);
            }
            else if (mpowerUps[3] == true)
            {
                BulletShot(1f, transform.forward - transform.right);
                BulletShot(1f, transform.forward + transform.right);
            }
            else if (mpowerUps[4] == true)
            {
                BulletShot(-1f, transform.right);
                BulletShot(1f, transform.right);
                BulletShot(1f, transform.forward - transform.right);
                BulletShot(1f, transform.forward + transform.right);
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (mpowerUps[0] == true)
            {
                BulletShot(1f, transform.right);

            }
            else if (mpowerUps[1] == true)
            {
                BulletShot(-1f, transform.forward);
            }
            else if (mpowerUps[2] == true)
            {
                BulletShot(-1f, transform.forward);
                BulletShot(1f, transform.forward);
            }
            else if (mpowerUps[3] == true)
            {
                BulletShot(-1f, transform.forward - transform.right);
                BulletShot(-1f, transform.forward + transform.right);
            }
            else if (mpowerUps[4] == true)
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
        mpowerUps[0] = false;
        mpowerUps[1] = false;
        mpowerUps[2] = false;
        mpowerUps[3] = false;
        mpowerUps[4] = false;

    }
    void BulletShot(float dir, Vector3 transfom)// Skotten skapas och skjuter dem.
    {

        Rigidbody bulletClone = (Rigidbody)Instantiate(mbulletRgb, transform.position, transform.rotation);
        bulletClone.velocity = transfom * dir * mbulletSpeed;
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
    }

    //Geter and seters

    public bool[] PowerUp
    {
        get { return mpowerUps; }
        set { mpowerUps = value; }


    }
    public int Power
    {
        get { return mpowerr; }
        set { mpowerr = value; }

    }
    public int PHealth
    {
        get { return mplayerHealth; }
        set { mplayerHealth = value; }

    }
}
