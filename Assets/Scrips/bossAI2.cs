using UnityEngine;
using System.Collections;

public class bossAI2 : MonoBehaviour
{
    private Vector3 waypoint;
    private float speed = 10;
    private int swag;
    private int dif = 6;

    // Use this for initialization
    void Start () {
        waypoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoint, step);
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "waypoint")
        {

            randomWaypoint();
        }
    }

    void randomWaypoint()
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
    }

