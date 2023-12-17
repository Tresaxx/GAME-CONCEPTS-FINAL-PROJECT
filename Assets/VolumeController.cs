using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider _musicSlider, _sfxSlider;
    public Text musicPercent, sfxPercent;
    private float percentage1, percentage2;

    public void Awake(){
        _musicSlider.value = AudioManager.Instance.musicSave;
        _sfxSlider.value = AudioManager.Instance.sfxSave;
    }

    public void Update(){
        percentage1 = _musicSlider.value * 100;
        percentage2 = _sfxSlider.value * 100;
        musicPercent.text = percentage1.ToString("F0") + "%";
        sfxPercent.text = percentage2.ToString("F0") + "%";
        MusicVolume();
        SFXVolume();
        AudioManager.Instance.sfxSave = _musicSlider.value;
        AudioManager.Instance.musicSave = _sfxSlider.value;
    }

    public void MusicVolume(){
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    
    public void SFXVolume(){
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
