using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public List<GameObject> tracks;
    public List<GameObject> tracksTemp;
    public List<Texture> tempTexture;
    public List<Vector3> trackspos;
    public GameObject spawnTriger;
    GameObject movedTrack;
    public Vector3 startTrackPosition;
    public Vector3 startTrack0Position;
    public Vector3 startTrack1Position;
    public Vector3 startTrack2Position;
    public Vector3 startTrack3Position;

    public Vector3 startTrack4Position;
    public Vector3 startTrack5Position;
    public Vector3 startTrack6Position;
    public Vector3 startTrack7Position;


    public Vector3 startTrack8Position;
    public Vector3 startTrack9Position;
    public Vector3 startTrack10Position;
    public Vector3 startTrack11Position;

    private float offset = 36.5f;

    public List<Texture> texture;
    // [SerializeField] GameObject ObstacleSpawn;
    public List<GameObject> ObstacleSpawn;
    public float x;
    public float z;
    public int boxCount = 0;
    // public Material ObstacleMaterial;
   
    
    void Awake()
    {
        startTrackPosition = transform.position;
    
        startTrack0Position = tracksTemp[0].transform.position;
        startTrack1Position = tracksTemp[1].transform.position;
        startTrack2Position = tracksTemp[2].transform.position;
        startTrack3Position = tracksTemp[3].transform.position;

         startTrack4Position = tracksTemp[4].transform.position;
        startTrack5Position = tracksTemp[5].transform.position;
        startTrack6Position = tracksTemp[6].transform.position;
        startTrack7Position = tracksTemp[7].transform.position;

         startTrack8Position = tracksTemp[8].transform.position;
        startTrack9Position = tracksTemp[9].transform.position;
        startTrack10Position = tracksTemp[10].transform.position;
        startTrack11Position = tracksTemp[11].transform.position;
    }
    void Start()
    {
        if(tracks != null && tracks.Count > 0)
        {
            tracks = tracks.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    void FixedUpdate()
    {
        // if(boxCount == 0)
        // {
        //     boxCount = 1;

            //Invoke("ObstaclesSpawn", 10);
       // }
       // ObstaclesSpawn();
       
          //  StartCoroutine(ObstaclesSpawner());

         
            //   Invoke("ObstaclesSpawn",10);
    }

    public void TrackPosStored()
    {
        tracks[0] = tracksTemp[0];
        tracks[1] = tracksTemp[1];
        tracks[2]= tracksTemp[2];
        tracks[3]=  tracksTemp[3];

        tracks[0].transform.position = startTrack0Position;
        tracks[1].transform.position = startTrack1Position;
        tracks[2].transform.position = startTrack2Position;
        tracks[3].transform.position =  startTrack3Position;


       tracksTemp[4].transform.position = startTrack4Position;
       tracksTemp[5].transform.position = startTrack5Position;
       tracksTemp[6].transform.position = startTrack6Position;
       tracksTemp[7].transform.position = startTrack7Position;

         startTrack8Position = tracksTemp[8].transform.position = startTrack8Position;
        startTrack9Position = tracksTemp[9].transform.position = startTrack9Position;
        tracksTemp[10].transform.position = startTrack10Position;
       tracksTemp[11].transform.position = startTrack11Position;

        //TextureChange();
    }

    public void MoveTrack()
    {
        movedTrack = tracks[0];
        tracks.Remove(movedTrack);
        float newZ = tracks[tracks.Count - 1].transform.position.z + offset;

        // // Obstacles code

        // Instantiate(ObstacleSpawn);  // BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation
        // // Vector3 obstaclePos = (0, 0, 11.62f);
        // int num = Random.Range(0, 2);
        // if(num == 0)
        // {
        //     x= 0.0f;
        // }else if (num == 1)
        // {
        //    x= -2.45f;

        // }else if (num == 2)
        // {
        //     x= 2.45f;
        // }
        // float z = tracks[0].transform.position.z;

        // ObstacleSpawn.transform.position = new Vector3(x,11.6f, z + 5f);

        // // Obstacles code End


        //active childrens

        // Transform[] allChildren = tracks[tracks.Count - 1].transform.GetComponentsInChildren<Transform>(true);
        // for(int i=0; i<allChildren.Length; i++)
        // {  
        //     if(allChildren[i].gameObject.activeInHierarchy)
        //     {
        //           Debug.Log("All Active Move Track");
        //     } 
        //     else{

        //         allChildren[i].gameObject.SetActive(true);
                
        //         Renderer rend = allChildren[i].gameObject.GetComponent<Renderer>();
            
        //         if(allChildren[i].gameObject.tag == "Box_1")
        //         {
        //             rend.material.mainTexture = texture[0];
        //         }
        //         else if(allChildren[i].gameObject.tag == "Box_2") 
        //         {
        //             rend.material.mainTexture = texture[1];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_3") 
        //         {
        //             rend.material.mainTexture = texture[2];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_4") 
        //         {
        //             rend.material.mainTexture = texture[3];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_5") 
        //         {
        //             rend.material.mainTexture = texture[4];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_6") 
        //         {
        //             rend.material.mainTexture = texture[5];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_7") 
        //         {
        //             rend.material.mainTexture = texture[6];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_8") 
        //         {
        //             rend.material.mainTexture = texture[7];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_9") 
        //         {
        //             rend.material.mainTexture = texture[8];
        //         }
        //          else if(allChildren[i].gameObject.tag == "Box_10") 
        //         {
        //             rend.material.mainTexture = texture[9];
        //         }
        //    }
        // }


        //end
    
        movedTrack.transform.position = new Vector3(-3.23f,0, newZ);
        tracks.Add(movedTrack);
        ObstaclesSpawn();
    }

    //   public void TextureChange()
    //   {
    //      Debug.Log("TextureChange()");
    //     for(int j=0; j<4; j++)
    //     { 
    //             Transform[] allChildren = tracks[j].transform.GetComponentsInChildren<Transform>(true);
    //             for(int i=0; i<allChildren.Length; i++)
    //             {  
    //                 if(allChildren[i].gameObject.activeInHierarchy)
    //                 {
    //                     Debug.Log(" Active Texture Change");
    //                 } 
    //                 else{

                       
    //                     if(allChildren[i].gameObject.tag != "Coin")
    //                     {
    //                          allChildren[i].gameObject.SetActive(true);
    //                     }
    //                 }

    //                 Renderer rend = allChildren[i].gameObject.GetComponent<Renderer>();
                    
    //                     if(allChildren[i].gameObject.tag == "Box_1")
    //                     {
    //                         rend.material.mainTexture = texture[0];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_2") 
    //                     {
    //                         rend.material.mainTexture = texture[1];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_3") 
    //                     {
    //                         rend.material.mainTexture = texture[2];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_4") 
    //                     {
    //                         rend.material.mainTexture = texture[3];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_5") 
    //                     {
    //                         rend.material.mainTexture = texture[4];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_6") 
    //                     {
    //                         rend.material.mainTexture = texture[5];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_7") 
    //                     {
    //                         rend.material.mainTexture = texture[6];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_8") 
    //                     {
    //                         rend.material.mainTexture = texture[7];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_9") 
    //                     {
    //                         rend.material.mainTexture = texture[8];
    //                     }
    //                     else if(allChildren[i].gameObject.tag == "Box_10") 
    //                     {
    //                         rend.material.mainTexture = texture[9];
    //                     }
    //             }
    //         }

    //   }

      public void ObstaclesSpawn()
      {
            //ObstacleMaterial.color = Color.red;
                int num = Random.Range(0,3);
                if(num == 0)
                {
                    //x= 0.0f;
                     Instantiate(ObstacleSpawn[0]);
                     ObstacleSpawn[0].transform.position = new Vector3(-1.912f,-0.344f,z + 110f);       
                }
                 if (num == 1)
                {
                  // x= -2.45f;
                   Instantiate(ObstacleSpawn[1]);
                     ObstacleSpawn[1].transform.position = new Vector3(0.22f,-0.344f,z + 110f);  

                }
                if(num == 2)
                {
                    ///x= 2.45f;
                     Instantiate(ObstacleSpawn[2]);
                     ObstacleSpawn[2].transform.position = new Vector3(2.07f,-0.344f,z + 110f);  
                }

                // if(boxCount == 1)
                // {
                //     Debug.Log("BoxCount = " + boxCount);
                //     Instantiate(ObstacleSpawn);
                //     ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 110f);       

                // }else{
                //          for(int i=0; i<boxCount; i++)
                //         {
                //             Instantiate(ObstacleSpawn);
                //             if(i==1) 
                //             {
                //                 ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 110f);  
                //             }else if(i == 2)
                //             {
                //                 ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 113f);
                //             }else if(i == 3)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 116f);
                //             }else if(i == 4)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 119f);
                //             }else if(i == 5)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 122f);
                //             }else if(i == 6)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 125f);
                //             }else if(i == 7)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 128f);
                //             }else if(i == 8)
                //             {   
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 131f);
                //             }else if(i == 9)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 134f);
                //             }else if(i == 10)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 137f);
                //             }else if(i == 11)
                //             {
                //                  ObstacleSpawn.transform.position = new Vector3(x,11.6f,z + 140f);
                //             }               
                //         }
                // }
        }

}
