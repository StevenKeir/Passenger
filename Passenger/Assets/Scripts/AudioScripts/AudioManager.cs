using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer masterMixer; //accesses master mixer



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


}
