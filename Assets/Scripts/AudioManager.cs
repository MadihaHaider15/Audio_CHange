using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;

    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }
        // PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }

    // public void SetVolume(string mode)
    // {
    //     foreach(Sound s in sounds)
    //     {
    //         if(s.name == "MainTheme")
    //         {
    //             if(mode == "speedUp")
    //             {
    //                 s.volume = 1f;
    //             }
    //             else if(mode == "slowdown"){
    //                 s.volume = 0.3f;
    //             }
    //         }

    //         if(s.name == "CoinPickUp")
    //         {
    //             if(mode == "speedUp")
    //             {
    //                 s.volume = 0.9f;
    //             }
    //             else if(mode == "slowdown"){
    //               s.volume = 0.1f;
    //             }
    //         }
    //     }
    // }

    public void StopSound(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Stop();
            }
        }
    }
}
