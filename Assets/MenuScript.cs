using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (gameObject.name == "StartButton")
        {
            print("start tapped");
            SceneManager.LoadScene("LevelSelect");
        }

        if(gameObject.name == "MenuButton")
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(gameObject.name == "ExitButton")
        {
            Application.Quit();
        }

    }
}
