using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {

    private int randomNumber;
    Rigidbody rgb;
    //Vector3 playerPos = new Vector3();
    public GameObject bullets;
    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
	
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
        print(randomNumber);
        if (coll.gameObject.tag == "level")
        UnityEngine.SceneManagement.SceneManager.LoadScene(randomNumber);

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullets, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {

        }


    }
}
