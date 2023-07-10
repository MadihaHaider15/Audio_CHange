using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class Audio_Change : MonoBehaviour
{
    public AudioSource audioSource;
    float[] samples = new float[512];
    float[] freqBands = new float[8];
    float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];

    float[] freqBandsHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    public static float Amplitude, AmplitudeBuffer;
    float AmplitudeHighest;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 

      // StartCoroutine(GetAudioClip());  
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();    
    }
    

    void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;

        for(int i=0; i<8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }
        if(currentAmplitude > AmplitudeHighest)
        {
            AmplitudeHighest = currentAmplitude;
        }

        Amplitude = currentAmplitude / AmplitudeHighest;
        AmplitudeBuffer = currentAmplitudeBuffer / AmplitudeHighest;

        Amplitude = Mathf.Round(Amplitude * 10f) / 10f;
     
      // Debug.Log("Amplitude  = "+ Amplitude);
        // if(Amplitude < 0.5)
        // {
        //      Debug.Log("Amplitude  = "+ Amplitude);
        // }

           // Debug.Log("AmplitudeHighest  = "+ AmplitudeHighest);

    }

    void CreateAudioBands()  // making value of freq 0-1
    {
        for(int i=0; i<8; i++)
        {
            if(freqBands[i] > freqBandsHighest[i])
            {
                freqBandsHighest[i] = freqBands[i];
            }
            audioBand[i] = (freqBands[i] / freqBandsHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandsHighest[i]);
        }
    }

    void GetSpectrumAudioSource(){
        audioSource.GetSpectrumData(samples,0,FFTWindow.Blackman);
    }

    void BandBuffer()  // for making values of freq smooth
    {
         for(int g=0; g<8; g++)
        {
            if(freqBands[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBands[g];
                bufferDecrease[g] = 0.005f;
            }
            if(freqBands[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()  // making 512 samples into 8 freq bands
    {
        /* 
           22050/512 = 43herts per sample

           20-60 herts
           60-250
           250-500
           500-2000
           2000-4000
           4000-6000
           6000-20000  
        
        */

        int count = 0;
        for(int i=0; i<8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i)*2;

            if(i == 7)
            {
                sampleCount +=2; // because of 510
            }
             for(int j=0; j<sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

           freqBands[i] = average * 10;
        }

    }

}
