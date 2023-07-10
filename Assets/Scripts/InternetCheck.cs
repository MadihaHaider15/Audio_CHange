using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InternetCheck : MonoBehaviour
{
    public static bool IntenetChecker;   

    void Update()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Network is not available");
            IntenetChecker = false;
        }
        else{
             IntenetChecker = true;
             Debug.Log("Network is available");
        }
    }
}
