using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //volume changing and saving using playerprefabs

    public float volumeSaved;
    public Slider volumeSlide;
    public AudioMixer audioMixer;

    private void Start()
    {
 
        
        volumeSaved = PlayerPrefs.GetFloat("SFXVolume", 0);
        audioMixer.SetFloat("SFXVolume", volumeSaved);
        volumeSlide.value = volumeSaved;
    }

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("SFXVolume", volume);

        volumeSaved = volume;
        PlayerPrefs.SetFloat("SFXVolume", volumeSaved);
    }
}
