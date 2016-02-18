using UnityEngine;
using System.Collections;

public class bossAI2 : MonoBehaviour
{
    [SerializeField]
    GameObject capsule;
    private Vector3 waypoint;
    [SerializeField]
    private float speed = 10;

    private int bossHealth;

    private int swag;

    private int dif = 6;

    [SerializeField]
    private float timer = 3f;

    [SerializeField]
    private Rigidbody bulletRgb;

    [SerializeField]
    private float invisTimer;

    [SerializeField]
    private float timeInvis;

    private Renderer rend;

    // Use this for initialization
    void Start() {
       
        waypoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        bossHealth = 30;

    }
    // Update is called once per frame
    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoint, step);


        timer -= Time.deltaTime; // Kollar tiden
        invisTimer -= Time.deltaTime;
        timeInvis -= Time.deltaTime;
        

        if(invisTimer <= 0.5f) // Gör bossen osynlig efter x sekunder och triggrar randomwaypoint
        {
            rend.enabled = false;
            randomWaypoint();
            invisTimer = 3;
        }

        if (timeInvis <= 0.5f) // Gör bossen synlig efter x sekunder
        {
            rend.enabled = true;
            timeInvis = 1;
        }

        if (timer <= 0.5f)// Varje x sekunder så ska den skjuta ett skott.
        {
            shootBullet();
        }


    }
    void OnCollisionEnter(Collision col) // Vid collision med waypoint triggrar randomWaypoint
    {
        if (col.gameObject.name == "waypoint")
        {

            randomWaypoint();
        }

        if (col.gameObject.tag == "bullet")
        {
            bossHealth--;
            if (bossHealth <= 0)
            {
                Destroy(gameObject);
                Instantiate(capsule, new Vector3(-6.07f, 0.145f, 3.34f), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    void randomWaypoint() // random generar 1 av 4 waypoints
    {
        swag = Random.Range(0, 4);

        while (swag == dif)
        {
            swag = Random.Range(0, 4);
        }
        switch (swag)
        {
            case 0:
                waypoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;
                dif = 0;
                break;

            case 1:
                waypoint = GameObject.FindGameObjectWithTag("waypoint1").transform.position;
                dif = 1;
                break;

            case 2:
                waypoint = GameObject.FindGameObjectWithTag("waypoint2").transform.position;
                dif = 2;
                break;

            case 3:
                waypoint = GameObject.FindGameObjectWithTag("waypoint3").transform.position;
                dif = 3;
                break;
        }
    }
    void shootBullet() // Skjuter kulan
    {
    
        Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRgb, transform.position, transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        timer = 1;

    }
}


