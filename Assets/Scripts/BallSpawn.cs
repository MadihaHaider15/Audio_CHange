using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public PlayerController PlayerController;
    [SerializeField] float Force = 45f;
    Rigidbody rb;
    Renderer Mainrend;
    public List<Texture> texture;
    public Material Ball_Mat;

    public GameObject obstacles;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Mainrend = rb.GetComponent<Renderer>();
        rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    void Update()
    {
         Time.timeScale = 1.2f;
         if(PlayerController.FireBall == 0)
         {
             Mainrend.material = Ball_Mat;
         }
    }

    void OnCollisionEnter(Collision collision)
    {     
        if(collision.gameObject.tag == "Box_1") 
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

            if(PlayerController.FireBall > 0 )
            {
               // FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                FireBoxDestroySound();
            }
            else{
               // FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                BoxDestroySound();
            }
            PlayerController.score = PlayerController.score +1;
            PlayerController.collisionCounts[0] = 0;
        }
        else if(collision.gameObject.tag == "Box_2") 
        {
            if( PlayerController.FireBall > 0 )   
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
              //  FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
               FireBoxDestroySound();
                PlayerController.collisionCounts[1] = 0;
                PlayerController.score = PlayerController.score +2;
          
            }
            if( PlayerController.FireBall == 0 )   
            {
               
                Renderer rend = collision.gameObject.GetComponent<Renderer>();  
                PlayerController.collisionCounts[1] = PlayerController.collisionCounts[1] + 1; 
        
                rend.material.mainTexture = texture[0];
                if(PlayerController.collisionCounts[1] == 2)
                {
                    collision.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                  //  FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                   BoxDestroySound();
                    PlayerController.score = PlayerController.score +2;
                    Debug.Log(PlayerController.score);
                    PlayerController.collisionCounts[1] = 0;
                   
                }
            }

        }
          else if(collision.gameObject.tag == "Box_3") 
        { 
            if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                 FireBoxDestroySound();
                PlayerController.collisionCounts[2] = 0;
                PlayerController.score = PlayerController.score +3;
           }
            if( PlayerController.FireBall == 0 )   
            {
                     Renderer rend = collision.gameObject.GetComponent<Renderer>();
                
                      PlayerController.collisionCounts[2] =  PlayerController.collisionCounts[2] + 1;
            
                     if(PlayerController.collisionCounts[2] == 0)  
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[2] == 1)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[2] == 2)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[2] == 3)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        //FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                         BoxDestroySound();
                        PlayerController.score = PlayerController.score +3;
                         PlayerController.collisionCounts[2] =  0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_4") 
        {
           
            if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                 FireBoxDestroySound();
                PlayerController.collisionCounts[3] = 0;
                PlayerController.score = PlayerController.score +4;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                  
                     PlayerController.collisionCounts[3] =  PlayerController.collisionCounts[3] + 1;

                    if(PlayerController.collisionCounts[3] == 0)  
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[3] == 1)
                    {
                        rend.material.mainTexture = texture[2];   
                    }
                    if(PlayerController.collisionCounts[3] == 2)
                    {
                        rend.material.mainTexture = texture[1];   
                    }
                    if(PlayerController.collisionCounts[3] == 3)
                    {
                        rend.material.mainTexture = texture[0];  
                    }

                    if(PlayerController.collisionCounts[3] == 4)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        //FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                         BoxDestroySound();
                          PlayerController.score = PlayerController.score +4;
                        PlayerController.collisionCounts[3] = 0;
                    }

           }
    
        }
        else if(collision.gameObject.tag == "Box_5") 
        {

             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                 FireBoxDestroySound();
                PlayerController.collisionCounts[4] = 0;
                PlayerController.score = PlayerController.score + 5;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
            
                      PlayerController.collisionCounts[4] =  PlayerController.collisionCounts[4] + 1;

                    if(PlayerController.collisionCounts[4] == 0)  
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[4] == 1)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[4] == 2)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[4] == 3)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[4] == 4)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[4] == 5)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                       // FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                        BoxDestroySound();
                         PlayerController.score = PlayerController.score + 5;
                        PlayerController.collisionCounts[4] = 0;
                    }

           }
           
        }
        else if(collision.gameObject.tag == "Box_6") 
        {
            
             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
               // FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                FireBoxDestroySound();
                PlayerController.collisionCounts[5] = 0;
                PlayerController.score = PlayerController.score + 6;
           }
            if( PlayerController.FireBall == 0 )   
            {
                     Renderer rend = collision.gameObject.GetComponent<Renderer>();
                      PlayerController.collisionCounts[5] =   PlayerController.collisionCounts[5] + 1;
                    
                    if(PlayerController.collisionCounts[5] == 0)  
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[5] == 1)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[5] == 2)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[5] == 3)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[5] == 4)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[5] == 5)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[5] == 6)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        //FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                         BoxDestroySound();
                         PlayerController.score = PlayerController.score + 6;
                         PlayerController.collisionCounts[5] = 0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_7") 
        {

             
             if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
               // FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                FireBoxDestroySound();
                PlayerController.collisionCounts[6] = 0;
                PlayerController.score = PlayerController.score + 7;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
    
                       PlayerController.collisionCounts[6] =   PlayerController.collisionCounts[6] + 1;
                    
                    if(PlayerController.collisionCounts[6] == 0)  
                    {
                        rend.material.mainTexture = texture[6];
                    }
                    if(PlayerController.collisionCounts[6] == 1)
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[6] == 2)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[6] == 3)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[6] == 4)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[6] == 5)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[6] == 6)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[6] == 7)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                       // FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                        BoxDestroySound();
                        PlayerController.score = PlayerController.score + 7;
                        PlayerController.collisionCounts[6] = 0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_8") 
        {
             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
               // FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                FireBoxDestroySound();
                PlayerController.collisionCounts[7] = 0;
                PlayerController.score = PlayerController.score + 8;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                   PlayerController.collisionCounts[7] =  PlayerController.collisionCounts[7] + 1;
                    
                    if(PlayerController.collisionCounts[7] == 0)  
                    {
                        rend.material.mainTexture = texture[7];
                    }
                    if(PlayerController.collisionCounts[7] == 1)
                    {
                        rend.material.mainTexture = texture[6];
                    }
                    if(PlayerController.collisionCounts[7] == 2)
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[7] == 3)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[7] == 4)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[7] == 5)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[7] == 6)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[7] == 7)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[7] == 8)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        //FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                         BoxDestroySound();
                           PlayerController.score = PlayerController.score + 8;
                         PlayerController.collisionCounts[7] = 0;
                    }
           }
           
        }
        else if(collision.gameObject.tag == "Box_9") 
        {
            if( PlayerController.FireBall > 0)
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //FindObjectOfType<AudioManager>().PlaySound("FireExplosion");
                 FireBoxDestroySound();
                PlayerController.collisionCounts[8] = 0;
                PlayerController.score = PlayerController.score + 9;
            }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                    PlayerController.collisionCounts[8] =  PlayerController.collisionCounts[8] + 1;
                    
                    if(PlayerController.collisionCounts[8] == 0)  
                    {
                        rend.material.mainTexture = texture[8];
                    }
                    if(PlayerController.collisionCounts[8] == 1)
                    {
                        rend.material.mainTexture = texture[7];
                    }
                    if(PlayerController.collisionCounts[8] == 2)
                    {
                        rend.material.mainTexture = texture[6];
                    }
                    if(PlayerController.collisionCounts[8] == 3)
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[8] == 4)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[8] == 5)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[8] == 6)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[8] == 7)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[8] == 8)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[8] == 9)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        //FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                         BoxDestroySound();
                        PlayerController.score = PlayerController.score + 9;
                        PlayerController.collisionCounts[8] = 0;
                    }
           }

        }
        else if(collision.gameObject.tag == "Box_10") 
        {
            if( PlayerController.FireBall > 0)
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
               // FindObjectOfType<AudioManager>().PlaySound("FireExplosion"); 
                FireBoxDestroySound();
                 PlayerController.collisionCounts[9] = 0;
                 PlayerController.score = PlayerController.score + 10;
            }
            if( PlayerController.FireBall == 0 )   
            {
                       Renderer rend = collision.gameObject.GetComponent<Renderer>();
                        PlayerController.collisionCounts[9] =  PlayerController.collisionCounts[9] + 1;
                        
                        if(PlayerController.collisionCounts[9] == 0)  
                        {
                            rend.material.mainTexture = texture[9];
                        }
                        if(PlayerController.collisionCounts[9] == 1)
                        {
                            rend.material.mainTexture = texture[8];
                        }
                        if(PlayerController.collisionCounts[9] == 2)
                        {
                            rend.material.mainTexture = texture[7];
                        }
                        if(PlayerController.collisionCounts[9] == 3)
                        {
                            rend.material.mainTexture = texture[6];
                        }
                        if(PlayerController.collisionCounts[9] == 4)
                        {
                            rend.material.mainTexture = texture[5];
                        }
                        if(PlayerController.collisionCounts[9] == 5)
                        {
                            rend.material.mainTexture = texture[4];
                        }
                        if(PlayerController.collisionCounts[9] == 6)
                        {
                            rend.material.mainTexture = texture[3];
                        }
                        if(PlayerController.collisionCounts[9] == 7)
                        {
                            rend.material.mainTexture = texture[2];
                        }
                        if(PlayerController.collisionCounts[9] == 8)
                        {
                            rend.material.mainTexture = texture[1];
                        }

                        if(PlayerController.collisionCounts[9] == 9)
                        {
                            rend.material.mainTexture = texture[0];
                        }  

                        if(PlayerController.collisionCounts[9] == 10)
                        {
                            collision.gameObject.SetActive(false);
                            gameObject.SetActive(false);
                           // FindObjectOfType<AudioManager>().PlaySound("BoxDestroy");
                            BoxDestroySound();
                            PlayerController.score = PlayerController.score + 10;
                            PlayerController.collisionCounts[9] = 0;
                        }
            }

        }
      
        else{
            gameObject.SetActive(false);
        }


        if(collision.gameObject.tag == "Enemy") 
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

     public void BoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)//Game_Manager.AudioSprite == Game_Manager.mic_On
        {
            FindObjectOfType<AudioManager>().PlaySound("BoxDestroy"); 
        }
        else{
                FindObjectOfType<AudioManager>().StopSound("BoxDestroy"); 
        }
    }

     public void FireBoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)
        {
            FindObjectOfType<AudioManager>().PlaySound("FireExplosion"); 
        }
        else{
                FindObjectOfType<AudioManager>().StopSound("FireExplosion"); 
        }
    }

}
