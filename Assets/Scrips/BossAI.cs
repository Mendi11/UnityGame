using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    GameObject mcapsule;
    private Vector3 mwaypoint;
    [SerializeField]
    private float mspeed = 10;

    private int mbossHealth;

    private int mswag;

    private int mdif = 6;

    [SerializeField]
    private float mtimer = 3f;

    [SerializeField]
    private Rigidbody mbulletRgb;

    [SerializeField]
    private float minvisTimer;

    [SerializeField]
    private float mtimeInvis;

    private Renderer mrend;

    // Use this for initialization
    void Start()
    {

        mwaypoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;
        mrend = GetComponent<Renderer>();
        mrend.enabled = true;

        mbossHealth = 30;

    }
    // Update is called once per frame
    void Update()
    {
        float step = mspeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mwaypoint, step);


        mtimer -= Time.deltaTime; // Kollar tiden
        minvisTimer -= Time.deltaTime;
        mtimeInvis -= Time.deltaTime;


        if (minvisTimer <= 0.5f) // Gör bossen osynlig efter x sekunder och triggrar randomwaypoint
        {
            mrend.enabled = false;
            randomWaypoint();
            minvisTimer = 3;
        }

        if (mtimeInvis <= 0.5f) // Gör bossen synlig efter x sekunder
        {
            mrend.enabled = true;
            mtimeInvis = 1;
        }

        if (mtimer <= 0.5f)// Varje x sekunder så ska den skjuta ett skott.
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
            mbossHealth--;
            if (mbossHealth <= 0)
            {
                Destroy(gameObject);
                Instantiate(mcapsule, new Vector3(-6.07f, 0.145f, 3.34f), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    void randomWaypoint() // random generar 1 av 4 waypoints
    {
        mswag = Random.Range(0, 4);

        while (mswag == mdif)
        {
            mswag = Random.Range(0, 4);
        }
        switch (mswag)
        {
            case 0:
                mwaypoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;
                mdif = 0;
                break;

            case 1:
                mwaypoint = GameObject.FindGameObjectWithTag("waypoint1").transform.position;
                mdif = 1;
                break;

            case 2:
                mwaypoint = GameObject.FindGameObjectWithTag("waypoint2").transform.position;
                mdif = 2;
                break;

            case 3:
                mwaypoint = GameObject.FindGameObjectWithTag("waypoint3").transform.position;
                mdif = 3;
                break;
        }
    }
    void shootBullet() // Skjuter kulan
    {

        Rigidbody bulletClone = (Rigidbody)Instantiate(mbulletRgb, transform.position, transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        mtimer = 1;

    }
}


