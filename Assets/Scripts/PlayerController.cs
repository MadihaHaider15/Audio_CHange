using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    //public BallSpawn BallSpawner;
    private Vector3 direction;
    public float forwardSpeed, maxSpeed, tempSpeed;

    private int desiredLane = 1;      //0:left, 1:middle, 2:right
    public float laneDistance = 2.0f;    //The distance between two lanes

    private Animation anim;
    public GameObject Player, FireButton, BaseBallBtn,AudioSource;
    public Material Character_Blur, Character;
    public TrackSpawnManager TrackSpawnManager;
    public List<GameObject> TempCoinsHideShow = new List<GameObject>();
    public List<GameObject> FireBallHideShow = new List<GameObject>();
    public List<GameObject> BoxesShow = new List<GameObject>();
    // public List<GameObject> CoinShow = new List<GameObject>();

    public bool movement, gameEnd, gamePause;
    public static int score;  
    public static int resetTrack;
    public static float FireBall;
    public Vector3 startPosition, yPos;

    public static int collisionCount, life;//Counting Ball hits
    public static bool restartTemp;
    public static int[] collisionCounts = new int[10];
    GameObject[] Coins;
    GameObject TempRoad;

    //Ball Spawn
    Renderer Mainrend;
    public GameObject SpawnBall;
    public Material Fire_Mat;
    public Material Ball_Mat;
    [Range(0,1)] public float alpha;

     public GameObject DirectionalLight;
    Light Light;
    Color color0 = Color.red;
    Color color1 = Color.blue;
   
     public Material ObstacleMaterial;
 
    void Awake()
    {
        startPosition = transform.position;
        yPos.y = startPosition.y;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();    

        // change
             Light = DirectionalLight.GetComponent<Light>();   
        //change 
        Time.timeScale = 1.2f;
  
        anim = Player.GetComponent<Animation>();
        gameEnd = false;
        gamePause = false;
        resetTrack = 0;
        // speedCount = 0;
        anim.Play("Idle");

        Mainrend = SpawnBall.GetComponent<Renderer>();  

        for(int i = 0; i < collisionCounts.Length; i++)
        {
            collisionCounts[i] = 0;
        }

        Coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    void Update()
    {
        TrackSpawnManager.playerPosZ = transform.position.z;  // for obstacles

        yPos.x = transform.position.x;  // fixed player's position at y 
        yPos.z = transform.position.z;
        transform.position = yPos;

         if(gamePause == true)
         {
            anim.Play("Idle");
         }
         //Speed increase in each second
        //  if(forwardSpeed < maxSpeed && movement == true && Game_Manager.restart == false && life == 0 && gameEnd == false && gamePause == false)
        //  {
        //     forwardSpeed += 0.1f * Time.deltaTime; 
        //  }
      
        //Change
             if(Audio_Change.Amplitude >= 0.7f && Audio_Change.Amplitude <= 1f && forwardSpeed < maxSpeed && movement == true && Game_Manager.restart == false && life == 0 && gameEnd == false && gamePause == false)
            {
                //forwardSpeed += 4f  * Time.deltaTime; 
            //  Light.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));
               
                GetBoxCount();
               // ObstacleMaterial.color = Color.red;
                Light.color = Color.red;
               
            }
            
        if(Audio_Change.Amplitude >= 0.4f && Audio_Change.Amplitude <= 0.6f && forwardSpeed < maxSpeed && movement == true && Game_Manager.restart == false && life == 0 && gameEnd == false && gamePause == false)
            {
                // if(forwardSpeed <= 25)
                // {
                //     forwardSpeed += 3f  * Time.deltaTime; 
                // }
                // else{
                //     forwardSpeed -= 1f  * Time.deltaTime; 
                // }
            //   Light.color = Color.Lerp(Color.blue, Color.black, Mathf.PingPong(Time.time, 1));
               
                GetBoxCount();
               // ObstacleMaterial.color = Color.green;
                Light.color = Color.green;
            }

            if(Audio_Change.Amplitude >= 0f && Audio_Change.Amplitude <= 0.3f && forwardSpeed < maxSpeed && movement == true && Game_Manager.restart == false && life == 0 && gameEnd == false && gamePause == false)
            {
                //  if(forwardSpeed <= 15)
                //  {
                //     forwardSpeed += 2f  * Time.deltaTime; 
                //  }
                //  else{
                //     forwardSpeed -= 1f  * Time.deltaTime; 
                //  }

                //  Light.color = Color.Lerp(Color.yellow, Color.white, Mathf.PingPong(Time.time, 1));
                
               
                GetBoxCount();
                 // ObstacleMaterial.color = Color.blue;
               Light.color = Color.blue;
        
            }

        //Change end
        if(Game_Manager.restart == true)
        {
            transform.position = startPosition;

            resetTrack = 1;
            desiredLane = 1;
            forwardSpeed = 8.0f;
            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            }
            //  for (int i = 0; i <  TempCoinsHideShow.Count; i++)
            //  {
            //     TempCoinsHideShow[i].SetActive(true);
            //  }
         
            // for (int i = 0; i < FireBallHideShow.Count; i++)
            //  {
            //      FireBallHideShow[i].SetActive(true);
            //  }
            Game_Manager.restart = false;
        }

        if(Game_Manager.reset == true)
        {
            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            }
            Game_Manager.reset = false;
        }

        if(life == 1)
        {
            Vector3 tempPosition = transform.position;
            tempPosition.z = tempPosition.z - 8f;
            transform.position = tempPosition;

            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            }
            
            TrackSpawnManager.TextureUpdate();
            tempSpeed = forwardSpeed;
         
            //Transform[] allChildren = TempRoad.transform.GetComponentsInChildren<Transform>(true);  // Hide Coins
            // for(int i=0; i<allChildren.Length; i++)
            // {
            //     if(allChildren[i].gameObject.tag == "Coin")
            //     {
            //         allChildren[i].gameObject.SetActive(false);  
            //     }
            // }
            life = 0;
        }

     if(movement)
        {
             AudioSource.SetActive(true);
        }
        else{
             AudioSource.SetActive(false);
        }
       Movement();
       StartCoroutine(FireBallTimerCoroutine());
       StartCoroutine(RestartTimerCoroutine());
    }

   private void Movement()
   {
            if(movement != false)
            {
                anim.Play("Run");
                direction.z =  forwardSpeed;   
                //Gather the inputs on which lane we should be
                if (SwipeManager.swipeRight)
                {
                    desiredLane++;
                    if (desiredLane == 3)
                        desiredLane = 2;
                }
                if (SwipeManager.swipeLeft)
                {
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                }

                //Calculate where we should be in the future
                Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
                if (desiredLane == 0)
                    targetPosition += Vector3.left * laneDistance;
                else if (desiredLane == 2)
                    targetPosition += Vector3.right * laneDistance;


                if (transform.position != targetPosition)
                {
                    Vector3 diff = targetPosition - transform.position;
                    Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
                    if (moveDir.sqrMagnitude < diff.magnitude)
                        controller.Move(moveDir);
                    else
                        controller.Move(diff);
                }

                controller.Move(direction * Time.deltaTime);
          }
   }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
            if(hit.transform.tag == "Enemy")   // hit.transform.tag == "Box_1" || hit.transform.tag == "Box_2" || hit.transform.tag == "Box_3" || hit.transform.tag == "Box_4" || hit.transform.tag == "Box_5" || // hit.transform.tag == "Box_6" || hit.transform.tag == "Box_7" || hit.transform.tag == "Box_8" || hit.transform.tag == "Box_9" || hit.transform.tag == "Box_10" ||
            {
                movement = false;
                gameEnd = true;
                //FindObjectOfType<AudioManager>().PlaySound("GameOver");
                if(PlayerPrefs.GetInt("Audio") ==  1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("GameOver"); 
                }
                else{
                    FindObjectOfType<AudioManager>().StopSound("GameOver"); 
                }
                anim.Play("Dizzy");
               // TempRoad = hit.transform.parent.gameObject;
           }
          
    }
    
    
     // To spawn Track
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpawnTriger")
        {
            //  for (int i = 0; i <  TempCoinsHideShow.Count; i++)
            //  {
            //     TempCoinsHideShow[i].SetActive(true);
            //  }
         
            // for (int i = 0; i < FireBallHideShow.Count; i++)
            //  {
            //      FireBallHideShow[i].SetActive(true);
            //  }

            // if(TempRoad != null)
            // {
            //       Transform[] allChildren = TempRoad.transform.GetComponentsInChildren<Transform>(true);
            //     for(int i=0; i<allChildren.Length; i++)
            //     {
            //         if(allChildren[i].gameObject.tag == "Coin")
            //         {
            //             allChildren[i].gameObject.SetActive(true);  
            //         }
            //     }
            //     TempRoad = null;
            // }
            
            TrackSpawnManager.TrackSpawnerTriggerEntered();
        }
        else if(other.gameObject.tag == "Coin")
        {
            TempCoinsHideShow.Add(other.gameObject); 
            //FindObjectOfType<AudioManager>().PlaySound("CoinPickUp");
                 if(PlayerPrefs.GetInt("Audio") ==  1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("CoinPickUp"); 
                }
                else{
                    FindObjectOfType<AudioManager>().StopSound("CoinPickUp"); 
                }
            other.gameObject.SetActive(false);
            score ++;    
        }
         else if(other.gameObject.tag == "Fire")
        {
            FireBallHideShow.Add(other.gameObject);
            other.gameObject.SetActive(false);
            FireBall =  FireBall + 1.0f;   
        }
    }

    // FireBall for spawn for 8 secs
    private IEnumerator FireBallTimerCoroutine()
    {
        if (FireBall > 0.0f)
        {
            Mainrend.material = Fire_Mat;
            float seconds = FireBall  * 8.0f;

            for(int i=0; i< seconds; i++)
            {
                FireButton.SetActive(true);
                BaseBallBtn.SetActive(false);
                yield return new WaitForSeconds(1);
                seconds = FireBall  * 8.0f;
            }
        }
      
        Mainrend.material = Ball_Mat;
        FireButton.SetActive(false);
        BaseBallBtn.SetActive(true);
        FireBall = 0;
    }

    private IEnumerator RestartTimerCoroutine()
    {
        if(restartTemp == true)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            for (int i = 0; i <  BoxesShow.Count; i++)
            { 
                BoxesShow[i].GetComponent<BoxCollider>().enabled = false;   
            }
    
            yield return new WaitForSeconds(2);

            for (int i = 0; i <  BoxesShow.Count; i++)  
            { 
                BoxesShow[i].GetComponent<BoxCollider>().enabled = true;   
            }
        }

        restartTemp = false;
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

    //GetBoxCount()

    public void GetBoxCount()
    {
        Debug.Log(" Audio_Change.Amplitude = " + Audio_Change.Amplitude);
        if(Audio_Change.Amplitude == 0f)
        {
            TrackSpawnManager.AmpliBox = 1;

        }else if(Audio_Change.Amplitude == 0.1f){
            TrackSpawnManager.AmpliBox = 2; 
        }else if(Audio_Change.Amplitude == 0.2f){
            TrackSpawnManager.AmpliBox = 3; 
        }else if(Audio_Change.Amplitude == 0.3f){
            TrackSpawnManager.AmpliBox = 4; 
        }else if(Audio_Change.Amplitude == 0.4f){
            TrackSpawnManager.AmpliBox = 5; 
        }else if(Audio_Change.Amplitude == 0.5f){
            TrackSpawnManager.AmpliBox = 6; 
        }else if(Audio_Change.Amplitude == 0.6f){
            TrackSpawnManager.AmpliBox = 7; 
        }else if(Audio_Change.Amplitude == 0.7f){
            TrackSpawnManager.AmpliBox = 8; 
        }else if(Audio_Change.Amplitude == 0.8f){
            TrackSpawnManager.AmpliBox = 9; 
        }else if(Audio_Change.Amplitude == 0.9f){
            TrackSpawnManager.AmpliBox = 10; 
        }else if(Audio_Change.Amplitude == 1f){
            TrackSpawnManager.AmpliBox = 11; 
        }
    }
   
}

