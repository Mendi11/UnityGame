using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {

    private int randomNumber;
    Rigidbody rgb;
    [SerializeField]
    Rigidbody bulletRgb;
   // bool right = true;
    float bulletSpeed = 15f;
   

    bool[] powerUps = new bool[1];
    // Use this for initialization

    void Start () {
        rgb = GetComponent<Rigidbody>();
        powerUps[0] = false;
      

    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(h,0,v);

        Vector3 vel = rgb.velocity;
        vel = movement.normalized;
        rgb.velocity = vel * 4f;
        
    }

    void OnCollisionEnter(Collision coll) {
        randomNumber = Random.Range(0,3);
        
        if (coll.gameObject.tag == "level")
        {
            print(randomNumber);
            UnityEngine.SceneManagement.SceneManager.LoadScene(randomNumber);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerUps[0] == true)
            {          
                BulletShot(1f, transform.forward);
            }
            else
                BulletShot(1f, transform.right);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (powerUps[0] == true)
            {
                BulletShot(-1f, transform.forward);
            }
            else
                BulletShot(-1f,transform.right);
        }


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
}
