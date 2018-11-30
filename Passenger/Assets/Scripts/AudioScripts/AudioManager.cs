using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {


    public int intensity;
    public bool coCheck = false;
    public AudioMixer masterMixer; //accesses master mixer
  

    void Start() {

        //intensity level set here

    }


    void Update() {

        if (!coCheck)
        {
            float currVolume;

            /* // Fade in test code 
            if (Input.GetKey(KeyCode.U))
            {
                masterMixer.GetFloat("Bass", out currVolume);
                StartCoroutine(FadeInMixer(masterMixer, "Bass", currVolume, 0f, 20f, coCheck));
            }
            else if (Input.GetKey(KeyCode.I))
            {
                masterMixer.GetFloat("Bass", out currVolume);
                StartCoroutine(FadeOutMixer(masterMixer, "Bass", currVolume, -80f, 20f, coCheck));
            }
            */


            if (intensity >= 1)
            {
                masterMixer.GetFloat("Bass", out currVolume);
                StartCoroutine(FadeInMixer(masterMixer, "Bass", currVolume, 0f, 20f, coCheck));
            }
            else 
            {
                masterMixer.GetFloat("Bass", out currVolume);
                StartCoroutine(FadeOutMixer(masterMixer, "Bass", currVolume, -80f, 20f, coCheck));
            }

            if (intensity >= 2)
            {
                masterMixer.GetFloat("Synths", out currVolume);
                StartCoroutine(FadeInMixer(masterMixer, "Synths", currVolume, 0f, 20f, coCheck));
            }
            else
            {
                masterMixer.GetFloat("Synths", out currVolume);
                StartCoroutine(FadeOutMixer(masterMixer, "Synths", currVolume, -80f, 20f, coCheck));
            }

            if (intensity >= 3)
            {
                masterMixer.GetFloat("Samples", out currVolume);
                StartCoroutine(FadeInMixer(masterMixer, "Samples", currVolume, 0f, 20f, coCheck));
            }
            else
            {
                masterMixer.GetFloat("Samples", out currVolume);
                StartCoroutine(FadeOutMixer(masterMixer, "Samples", currVolume, -80f, 20f, coCheck));
            }

            if (intensity >= 4)
            {
                masterMixer.GetFloat("Beats", out currVolume);
                StartCoroutine(FadeInMixer(masterMixer, "Beats", currVolume, 0f, 20f, coCheck));
            }
            else 
            {
                masterMixer.GetFloat("Beats", out currVolume);
                StartCoroutine(FadeOutMixer(masterMixer, "Beats", currVolume, -80f, 20f, coCheck));
            }
             
        }
    }


    public void SetMasterLvl(float masterLvl) {
        masterMixer.SetFloat("Master", masterLvl);
    }

    public void SetBassLvl(float bassLvl)
    {
        masterMixer.SetFloat("Bass", bassLvl);
    }
    public void SetBass2Lvl(float bass2Lvl)
    {
        masterMixer.SetFloat("Bass2", bass2Lvl);
    }

    public void SetBeatsLvl(float beatsLvl)
    {
        masterMixer.SetFloat("Beats", beatsLvl);
    }
    public void SetBeats2Lvl(float beats2Lvl)
    {
        masterMixer.SetFloat("Beats2", beats2Lvl);
    }

    public void SetSynthsLvl(float synthsLvl)
    {
        masterMixer.SetFloat("Synths", synthsLvl);
    }
    public void SetSynths2Lvl(float synths2Lvl)
    {
        masterMixer.SetFloat("Synths2", synths2Lvl);
    }

    public void SetSamplesLvl(float samplesLvl)
    {
        masterMixer.SetFloat("Samples", samplesLvl);
    }
    public void SetSamples2Lvl(float samples2Lvl)
    {
        masterMixer.SetFloat("Samples2", samples2Lvl);
    }


    //Fade in/Outs

    public static IEnumerator FadeInMixer(AudioMixer audioMixer, string varName, float startVolume, float maxVolume, float FadeTime, bool coCheck)
    {

        coCheck = true;
        float currVolume = startVolume;

        while (currVolume < maxVolume)
        {
            currVolume += (Time.deltaTime * FadeTime);

            audioMixer.SetFloat(varName, currVolume);

            yield return null;

        }
        coCheck = false;
        yield return null;
    }

    public static IEnumerator FadeOutMixer (AudioMixer audioMixer, string varName, float startVolume, float minVolume, float FadeTime, bool coCheck)
    {
        coCheck = true;
          float currVolume = startVolume;

          while (currVolume >= minVolume)
        {
            currVolume -= (Time.deltaTime * FadeTime);

            audioMixer.SetFloat(varName, currVolume);

            yield return null;

        }
        coCheck = false;
        yield return null;
    }


}
