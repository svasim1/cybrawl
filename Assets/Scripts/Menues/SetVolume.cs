using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void Start()
    {
        // Set the initial values of the sliders to the current volume levels
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("MasterVol", 1f)) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol", 1f)) * 20);
        mixer.SetFloat("SFXVol", Mathf.Log10(PlayerPrefs.GetFloat("SFXVol", 1f)) * 20);
    }
    public void SetMaster (float sliderValue)
    {
        // Set the volume of the Master mixer to the value of the slider
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }
    public void SetMusic (float sliderValue)
    {
        // Set the volume of the Music mixer group to the value of the slider
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }

    public void SetSFX (float sliderValue)
    {
        // Set the volume of the SFX mixer group to the value of the slider
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }
}