using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
       SceneManager.LoadScene(1);

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
