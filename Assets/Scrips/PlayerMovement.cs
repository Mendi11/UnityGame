﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private int playerHealth;
    private int randomNumber;
    private Rigidbody rgb;
    [SerializeField]
    private Rigidbody bulletRgb;
    private float bulletSpeed = 15f;
    private int powerr = 3;
    [SerializeField]
    
    private Counter diff;


    bool[] powerUps = new bool[5];
    // Use this for initialization
    void Awake()
    {
      
        diff = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
    }

    void Start()
    {

        playerHealth = 3;
        rgb = GetComponent<Rigidbody>();
        //bulletRgb = GameObject.FindGameObjectWithTag("bullet").GetComponent<Rigidbody>();

        PowerUpStart();
        powerUps[0] = true;

    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(h, 0, v);

        Vector3 vel = rgb.velocity;
        vel = movement.normalized;
        rgb.velocity = vel * 5f;

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

            randomNumber = Random.Range(2, i);
            UnityEngine.SceneManagement.SceneManager.LoadScene(randomNumber);
        }

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "eBullet")
        {
            playerHealth--;
            Debug.Log("Hit by something, health:" + playerHealth);

            if (playerHealth <= 0)
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
    void BulletShot(float dir, Vector3 transfom)// Skotten skapas och skjuter dem.
    {

        Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRgb, transform.position, transform.rotation);
        bulletClone.velocity = transfom * dir * bulletSpeed;
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
    }

    //Geter and seters

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
    public int PHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }

    }
}