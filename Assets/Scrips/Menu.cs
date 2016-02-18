using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{


    Counter count;
    // Use this for initialization
    void Start()
    {
        count = GameObject.FindGameObjectWithTag("Text").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
       SceneManager.LoadScene(1);
        count.PowerupC = 0;

    }
    public void LevelOne()
    {
       SceneManager.LoadScene(2);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelThree()
    {

       SceneManager.LoadScene(4);
    }

}
