using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepiece : MonoBehaviour
{
    public string pieceStatus = "idle";
    public Transform edgeParticles; 
    public bool RandomMovement=true;
    public Vector3 movement;
    public int seconds = 4;
    public float timer = 0f;
    private float curveAmount = 10f;
    private float rotateSpeed = 100.0f;
    public bool isrotating = false;
    public float angle;
    public string checkPlacement = "";
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        // movement = new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0);
        angle = UnityEngine.Random.Range(-180f,180f);
        target = new Vector3(UnityEngine.Random.Range(-30f, 30f), UnityEngine.Random.Range(-15f, 15f), 0);
    }

    // Update is called once per frame
    void Update()
    {

        if(RandomMovement==true){
            initRandomMovement();
        }

        if(RandomMovement==false && pieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
            transform.position = objPosition;
        }

        if(RandomMovement==false && pieceStatus == "pickedup" && Input.GetKeyDown(KeyCode.Mouse1))
        {
            isrotating = true;
            // transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0.0f, 0.0f, -curveAmount), rotateSpeed * Time.deltaTime);
            transform.Rotate(0,0,-curveAmount);
        }

        if(pieceStatus == "pickedup" && Input.GetKeyDown(KeyCode.Mouse0)){
            checkPlacement = "y";
        }
    }



    void OnTriggerStay2D(Collider2D other)
    {
        // if(Input.GetKeyDown(KeyCode.Mouse0)){
        //     checkPlacement = "y";
        // }
        print("Collidion detected");
        if((other.gameObject.name == "PlacementChecker") && (checkPlacement == "y"))
        {
            print(Math.Abs(transform.rotation.eulerAngles.z - other.gameObject.transform.rotation.eulerAngles.z));
            if(Math.Abs(transform.rotation.eulerAngles.z - other.gameObject.transform.rotation.eulerAngles.z) <= 20 || Math.Abs(transform.rotation.eulerAngles.z - other.gameObject.transform.rotation.eulerAngles.z) >= 340)
            {
                print("found boxcollider");
                GetComponent<BoxCollider2D> ().enabled = false;
                transform.position = other.gameObject.transform.position;
                transform.rotation = other.gameObject.transform.rotation;
                pieceStatus = "locked";
            }
            checkPlacement = "n";
            // GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);

        }

        if((other.gameObject.name != "PlacementChecker") && (checkPlacement == "y"))
        {
            // GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, .5f);
            checkPlacement = "n";
        }
    }

    void OnMouseDown(){
        pieceStatus="pickedup";
        checkPlacement = "n";
    }

    void initRandomMovement(){
        // print("moving piece number");
        if (timer <= seconds) {
            // basic timer
            timer += Time.deltaTime;
            // percent is a 0-1 float showing the percentage of time that has passed on our timer!
            float percent = timer / seconds;

            // multiply the percentage to the difference of our two positions
            // and add to the start
            //  transform.Rotate(0,0,-curveAmount);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), (Math.Abs(angle)/seconds) * Time.deltaTime);
            // transform.Translate(movement * Time.deltaTime * 1); 
            // Vector3 Difference = target.position;
            transform.position = target*percent;
        }
        else{
            RandomMovement=false;
        }
    }
}
