using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using TMPro;
using UnityEngine.Networking;

public class Game_Manager : MonoBehaviour
{
   public static Game_Manager instance; 
   public PlayerController PlayerController;
   public Audio_Change Audio_Change;
   public TMP_Text ScoreTxt, YourScoreTxt;
   public TMP_Text HighestScoreTxt, YourHighestScoreTxt;

   int highscores;
   [SerializeField] [Range(0,1)] float progress = 0f;

   public GameObject MainMenuScreen; 
   public GameObject AdScreen; 
   public GameObject Settings; 
   bool tap, tempLife;
   public static bool showAds, restart, reset, loadAd, restartBtn;  

    [SerializeField] GameObject BallSpawnPoint;
    [SerializeField] GameObject Ball; 

    public TMP_Text DisplayText;
    public int TimerCountDown;
    
    public Sprite mic_Off;
    public Sprite mic_On;
    public Sprite music_On;
    public Sprite music_Off;


    public List<AudioClip> audioClips = new List<AudioClip>();
    public GameObject MusicChangeScreen, tempPanal;
    public InputField mainInputField;
    bool btn;
    string finalPath;

    private void Awake()   
    {
        instance = this;
    }

    void Start()
    {
        highscores = PlayerPrefs.GetInt("highscores", 0);
        ScoreTxt.text = PlayerController.score.ToString();
        YourScoreTxt.text = PlayerController.score.ToString();
        HighestScoreTxt.text = highscores.ToString();
        YourHighestScoreTxt.text = highscores.ToString();
        showAds = false;

        // music get clips name from an array 
        //  tempPanal =  MusicChangeScreen.transform.GetChild(0).gameObject;
        //   for (int i = 0; i < audioClips.Count; i++)
        //     {
        //         tempPanal.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = audioClips[i].name;
        //     }

        //for web link music //    StartCoroutine(GetAudioClip());// for music change


    }

    void Update()
    {
        // if(btn == true) for music 
        // {
        //      StartCoroutine(LoadAudio());
        //      btn = false;
        // }
         ShowScores();
         VolSetting();
        
      if(PlayerController.movement == false && PlayerController.gameEnd == true && MainMenuScreen.transform.GetChild(4).gameObject.activeInHierarchy == false)  
       {

            if(PlayerController.score > highscores)
            {
                    HighestScoreMenu();
            }
            else{
                    GameScoreMenu();
            }
       }
      if(showAds == true && loadAd == false && InternetCheck.IntenetChecker == true)
        {
             AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            ResumeGameAfterAd();
        }
        else{
            AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }
         
        if(loadAd == true)
        {
            AdScreen.transform.GetChild(4).gameObject.SetActive(true);
            AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }

        if(loadAd == false)
        {
            AdScreen.transform.GetChild(4).gameObject.SetActive(false);
            AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }

        if(InternetCheck.IntenetChecker == false)
        {
            AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            AdScreen.transform.GetChild(5).gameObject.SetActive(true);
        }
        else{
             AdScreen.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
             AdScreen.transform.GetChild(5).gameObject.SetActive(false);
        }
         // ball Spawn by tap
         if(SwipeManager.swipeLeft == false && SwipeManager.swipeRight == false)
         {
            tap = true; 
         }
         else{
            tap = false;
         }

        //   if(Settings.transform.GetChild(2).gameObject.GetComponent<Image>().sprite == music_On)
        // {
        //     FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        // }
        // else{
        //     FindObjectOfType<AudioManager>().StopSound("MainTheme");
        // }

       
    
    }

    private void ShowScores()
    {
        ScoreTxt.text = PlayerController.score.ToString();
        YourScoreTxt.text = PlayerController.score.ToString();
        if(highscores < PlayerController.score)
        {
            PlayerPrefs.SetInt("highscores", PlayerController.score);
            YourHighestScoreTxt.text =  PlayerController.score.ToString();
        }
    }

    public void GameStart()
    {
        PlayerController.movement = true;
        MainMenuScreen.transform.GetChild(0).gameObject.SetActive(false);
        MainMenuScreen.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void GamePause()
    {
         BtnSound();
        if(MainMenuScreen.transform.GetChild(3).gameObject.activeInHierarchy == false)
        {
            PlayerController.gamePause = true; 
            PlayerController.movement = false; 
            MainMenuScreen.transform.GetChild(1).gameObject.SetActive(false);
            MainMenuScreen.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void ResumeGame()
    {
         BtnSound();
        PlayerController.gamePause = false; 
        PlayerController.movement = true; 
        MainMenuScreen.transform.GetChild(2).gameObject.SetActive(false);
        MainMenuScreen.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void ResumeGameAfterAd()
     {
         BtnSound();  
        MainMenuScreen.transform.GetChild(4).gameObject.SetActive(false);
        MainMenuScreen.transform.GetChild(5).gameObject.SetActive(true);
        PlayerController.life = 1;
        showAds = false;
        ResetGame();
     }

    public void AdsMenu()
    {
        if(MainMenuScreen.transform.GetChild(3).gameObject.activeInHierarchy == true)
        {
           MainMenuScreen.transform.GetChild(3).gameObject.SetActive(false);
        }
        else{
             MainMenuScreen.transform.GetChild(6).gameObject.SetActive(false);
        }
            MainMenuScreen.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void GameScoreMenu()
    {
        MainMenuScreen.transform.GetChild(3).gameObject.SetActive(true);
        MainMenuScreen.transform.GetChild(1).gameObject.SetActive(false);
    }

     public void HighestScoreMenu()
    {
        MainMenuScreen.transform.GetChild(6).gameObject.SetActive(true);
        MainMenuScreen.transform.GetChild(1).gameObject.SetActive(false);
    }

     public void BackToMenuFromPauseMenu()
    {
         BtnSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        reset = true;
        PlayerController.FireBall = 0;   
    }

    public void BackToMenuFromGameScoreMenu()
    {
       BtnSound();
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
       reset = true;
       PlayerController.FireBall = 0;  
    }

    public void ResetGame()
    {
        BtnSound();
        if(PlayerController.life == 1)
        {
            Debug.Log("PlayerController.life == 1");
            tempLife = true;
        }
        else{
                MainMenuScreen.transform.GetChild(4).gameObject.SetActive(false);
                MainMenuScreen.transform.GetChild(5).gameObject.SetActive(true);
                PlayerController.score = 0; 
                restart = true;
        }
    
        PlayerController.gameEnd = false;
        reset = true;
        PlayerController.FireBall = 0; 
    }

    public void RestartBtn()
    {
         if(PlayerController.life == 0)
        {
             BtnSound();
            PlayerController.movement = true;
            MainMenuScreen.transform.GetChild(1).gameObject.SetActive(true);
            MainMenuScreen.transform.GetChild(5).gameObject.SetActive(false);
        }

        if(tempLife == true)
        {
            PlayerController.restartTemp = true;
            tempLife = false;
        }
    }

    public void GameQuit()
    {
        BtnSound();
        Application.Quit();
    }

    public void BallFire()
    {
        Instantiate(Ball, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);

        if(PlayerPrefs.GetInt("Audio") ==  1)
        {
             FindObjectOfType<AudioManager>().PlaySound("BallFire"); 
        }
        else{
             FindObjectOfType<AudioManager>().StopSound("BallFire"); 
        }
    }


    public void AudioToggle()
    {
        Sprite AudioSprite = Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite;   
          if(AudioSprite == mic_On)
          {
              AudioSprite = mic_Off;
            
              PlayerPrefs.SetInt("Audio", 0);
          }
          else{

             AudioSprite = mic_On;
          
             PlayerPrefs.SetInt("Audio", 1);
          }

        Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite = AudioSprite;
    }

     public void MusicToggle()
    {
        //Sprite tempSprite = Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite;

        Sprite tempSprite = Settings.transform.GetChild(2).gameObject.GetComponent<Image>().sprite;
          if(tempSprite == music_On)
          {
             FindObjectOfType<AudioManager>().StopSound("MainTheme");
              tempSprite = music_Off;
              PlayerPrefs.SetInt("Music", 0);
          }
          else{
            FindObjectOfType<AudioManager>().PlaySound("MainTheme");
             tempSprite = music_On;
             PlayerPrefs.SetInt("Music", 1);
          }

        // Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite = tempSprite;

         Settings.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = tempSprite;
    }

    public void BtnSound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)
        {
            FindObjectOfType<AudioManager>().PlaySound("ButtonClicked"); 
        }
        else{
                FindObjectOfType<AudioManager>().StopSound("ButtonClicked"); 
        }
    }

    public void VolSetting()
    {
        if(PlayerPrefs.GetInt("Audio") ==  0)
        {
           Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite = mic_Off;
        }
        else{
             Settings.transform.GetChild(1).gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite = mic_On;
        }

        //  if(PlayerPrefs.GetInt("Music") ==  0)
        // {
        //    Settings.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = music_Off;
        // }
        // else{
        //      Settings.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = music_On;
        // }

    }

       public void audioBtnClicked()
    {
        PlayerController.gamePause = true; 
        PlayerController.movement = false; 
    }

    public void audioExitBtnClicked()
    {
        PlayerController.gamePause = false; 
        PlayerController.movement = true; 
    }

     public void MusicUrl()
    {
        string FileType =  NativeFilePicker.ConvertExtensionToFileType("mp3");
       
         NativeFilePicker.Permission permission = NativeFilePicker.PickMultipleFiles( ( paths ) =>
			{
				if( paths == null )
					Debug.Log( "Operation cancelled" );
				else
				{
					for( int i = 0; i < paths.Length; i++ )
                       {
						    Debug.Log( "Picked file: " + paths[i] );
                            finalPath = paths[i];
                            StartCoroutine(LoadAudio());
                       }
                        
				}
			}, FileType);
         
        btn = true;
    }

      IEnumerator LoadAudio()
    {
                using (var www = new WWW("file://" + finalPath))
                {
                    yield return www;
                    if (string.IsNullOrEmpty(www.error))
                    {
                       Audio_Change.audioSource.clip = www.GetAudioClip(false, false, AudioType.MPEG);
                       Audio_Change.audioSource.Play();

                    }

                    audioExitBtnClicked();
                } 
        btn=false;  
   }

    // public void audioBtnClicked()
    // {
    //     PlayerController.gamePause = true; 
    //     PlayerController.movement = false; 
    // }

    // public void audioExitBtnClicked()
    // {
    //     PlayerController.gamePause = false; 
    //     PlayerController.movement = true; 
    // }

    // public void MusicUrl()
    // {
       
    //    path =  mainInputField.text;
    //     Debug.Log(path);
    //     btn = true;
    //      audioExitBtnClicked();
    // }

    // // public void OpenFileExplorer() from computer
    // // {
    // //     path = EditorUtility.OpenFilePanel("Overwrite with mp3",".mp3", ".wav");   // Computer Explorer open 
    // //     Debug.Log("Path = " + path);
    // //     btn = true;
    // // }

    //  // public void ClipPlay()  // custom clip get from array 
    // // {
    // //     string TempClipname = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text ;
      
    // //     for (int i = 0; i < audioClips.Count; i++)
    // //         {
    // //             if(TempClipname == audioClips[i].name)
    // //             {
    // //                Audio_Change.audioSource.clip = audioClips[i];
    // //                  Audio_Change.audioSource.Play();
    // //             }  
    // //         }
    // // }

    //  IEnumerator GetAudioClip()  // From Web Link
    // {
    //    Debug.Log("Courotuueen start");
    //     using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path , AudioType.MPEG))
    //     {
    //         yield return www.SendWebRequest();
 
    //         if (www.isNetworkError)
    //         {
    //             Debug.Log(www.error);
    //               Debug.Log("Error");
    //         }
    //         else
    //         {
    //             AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
    //             Audio_Change.audioSource.clip = myClip;
    //             Audio_Change.audioSource.Play();
    //             Debug.Log("Audio is playing.");
    //             Debug.Log("Audio_Change.audioSource.clip = " + myClip.name);
    //         }
    //     }

    // }


    // // IEnumerator LoadAudio()   // from Computer Device
    // // {
    // //     string url = string.Format("file://{0}", path);
    // //     WWW www = new WWW(url);
    // //     yield return www;

    // //     Audio_Change.audioSource.clip = NAudioPlayer.FromMp3Data(www.bytes);
    // //     Audio_Change.audioSource.Play();
    // //     audioExitBtnClicked();
    // // }
    
}
