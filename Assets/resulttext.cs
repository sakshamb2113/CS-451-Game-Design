using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class resulttext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().text = TilesGen.result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
