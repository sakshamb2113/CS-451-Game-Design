using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static float currentTime;
    public int startMinutes = 2;
    public Text currentTimeText;
    public bool timerActive;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes*60;
        currentTime = 120;
        StartTimer();        
    }

    // Update is called once per frame
    void Update()
    {
        // currentTimeText.text = currentTime.ToString();
        // GetComponent<TextMesh>().text = currentTimeText.text;
        if(timerActive == true){
            currentTime = currentTime - Time.deltaTime;
        }
        GetComponent<TextMesh>().text = "Time Left: " +currentTime.ToString()+" s";
    }


    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
