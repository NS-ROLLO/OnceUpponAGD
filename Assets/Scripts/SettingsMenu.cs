using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    private float volu ;
    private int quality ;
    [SerializeField] Slider volSlider;
    [SerializeField] TMP_Dropdown qualDropdown;
    private void Start()
    {
      
            volu = PlayerPrefs.GetFloat("lastVol");
            SetVolume(volu);
            volSlider.value = volu;

            quality = PlayerPrefs.GetInt("lastQ");
            SetQuality(quality);
            qualDropdown.value = quality;
           
      

    }
    public AudioMixer audiuMixer;
    public void SetVolume(float vol)
    {
        audiuMixer.SetFloat("volume", vol);
        volu = vol;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        quality = qualityIndex;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("lastQ", quality);
        PlayerPrefs.SetFloat("lastVol", volu);
    }
}
