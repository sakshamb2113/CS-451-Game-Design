using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class levelselect : MonoBehaviour
{
    public static int whichlevel;
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
        if (gameObject.name == "Level 1 text")
        {
            whichlevel = 1;
        }

        if (gameObject.name == "Level 2 text")
        {
            whichlevel = 2;
        }

        if(gameObject.name == "Level 3 text")
        {
            whichlevel = 3;
        }

        if(gameObject.name == "Level 4 text")
        {
            whichlevel = 4;
        }
        
        SceneManager.LoadScene("Puzzle1");
    }
}
