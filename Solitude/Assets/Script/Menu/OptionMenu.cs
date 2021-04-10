using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public float musicVolume;
    public float sfxVolume;

    void Start() {
        musicVolume = GlobalAudioControl.AudioInstance.musicVolume;
        sfxVolume = GlobalAudioControl.AudioInstance.sfxVolume;

        mixer.SetFloat("MusicVolume", musicVolume);
        mixer.SetFloat("SFXVolume", sfxVolume);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void SetMusicVolume(float silderValue)
    {
        musicVolume = silderValue;
        mixer.SetFloat("MusicVolume", musicVolume);
        GlobalAudioControl.AudioInstance.musicVolume = musicVolume;
    }

    public void SetSFXVolume(float silderValue)
    {
        sfxVolume = silderValue;
        mixer.SetFloat("SFXVolume", sfxVolume);
        GlobalAudioControl.AudioInstance.sfxVolume = sfxVolume;
    }

}
