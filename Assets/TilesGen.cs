using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TilesGen : MonoBehaviour
{
  private List<Sprite> imgs = new List<Sprite>();
  public List<GameObject> MyImages = new List<GameObject>();

  public bool areMoving = true;
  public string DirName;
  public static string result = "";

  void Start()
  {
    // generate basic sprites
    CreatePlacementChecker();
    CreateBaseTexture();

  }

  void CreatePlacementChecker()
  {
    var path = @"E:\cs451\New Unity Project\Assets\Resources\";
    string FileName = "Level"+levelselect.whichlevel;
    path = path + FileName ;
    path = path.Replace(@"\","/");
    GameObject CentralCollider = new GameObject("PlacementChecker");
    CentralCollider.AddComponent(typeof(SpriteRenderer));
    CentralCollider.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(FileName);
    print(path);
    CentralCollider.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.4f);
    CentralCollider.AddComponent<BoxCollider2D>();
    CentralCollider.GetComponent<BoxCollider2D>().isTrigger = true;
    // CentralCollider.GetComponent<BoxCollider2D>().size = new Vector2(3f, 3f);
    CentralCollider.transform.position = new Vector3(0,0,2);
    CentralCollider.transform.localScale = new Vector3(1.5f,1.5f,0);
  }


  void CreateBaseTexture()
  {
    var path = @"E:\cs451\New Unity Project\Assets\Resources\";
    DirName = "Level"+levelselect.whichlevel;
    path=path+DirName+@"\";
    // print(path);
    var info = new DirectoryInfo(path);
    var fileInfo = info.GetFiles();
    int num=0;
    foreach (System.IO.FileInfo fi in fileInfo){
      string FileName = fi.Name;
      if(fi.Extension == ".png" && FileName.Substring(FileName.Length - 4)!="meta"){
        InitTile(fi.FullName,num);
        num++;
      }
    }

    for (int i = 0; i < MyImages.Count; i++){
      for (int j = i+1; j < MyImages.Count; j++){
          Physics2D.IgnoreCollision(MyImages[i].GetComponent<BoxCollider2D>(), MyImages[j].GetComponent<BoxCollider2D>(), false);
      }
    }

  }

  void InitTile(string path, int num)
  {
    print("Adding image "+num+" to MyImages");
    MyImages.Add(new GameObject("A"+(num+1)));
    MyImages[num].AddComponent(typeof(SpriteRenderer));
    path = path.Replace(@"\","/");
    string FileName = Path.GetFileNameWithoutExtension(path);
    Sprite MySprite = Resources.Load<Sprite>(DirName+"/"+FileName);
    // print(DirName+"/"+FileName);
    imgs.Add(MySprite);
    // Debug.Log("Done loading");
    MyImages[num].GetComponent<SpriteRenderer>().sprite = imgs[num];
    MyImages[num].AddComponent<BoxCollider2D>();
    MyImages[num].GetComponent<BoxCollider2D>().isTrigger = true;
    // MyImages[num].GetComponent<BoxCollider2D>().size = new Vector2(4f, 4f);
    MyImages[num].AddComponent<movepiece>();
    MyImages[num].AddComponent<Rigidbody2D>();
    
    MyImages[num].GetComponent<Rigidbody2D>().gravityScale = 0;
    MyImages[num].transform.localScale = new Vector3(1.5f, 1.5f, 0);
    // Debug.Log("image number: "+num);
  }

  void Spreadout()
  {
    int num=1;
    foreach (GameObject PuzzlePiece in MyImages){
      Vector3 movement = new Vector3(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(-50f, 50f), 0);
      PuzzlePiece.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
      PuzzlePiece.transform.Translate(movement * Time.deltaTime * 10);
      // print("Puzzle Piece : " + num + " Is Moving");
      num++;
    }
    areMoving=false;
  }
  void Update()
  {
    // initialise with random movement
    // if(areMoving==true){
    //   Spreadout();
    // }
    Checktime();
  }

  void Checktime()
    {
        if(timer.currentTime<=0){
            result = "Bad luck! You couldn't solve it.";
            SceneManager.LoadScene("Congrats");
        }
        else{
          // if all pieces are locked 
          int flg=0;
            for(int i = 0; i < MyImages.Count; i++)
            {
              if(MyImages[i].GetComponent<movepiece>().pieceStatus != "locked")
              {
                flg=1;
                break;
              }
            }

            if(flg==0){
              //pass
              result = "Congratulations! You solved the level.";
              SceneManager.LoadScene("Congrats");
            }
        }
    }
}

