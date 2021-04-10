using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mixer;
<<<<<<< HEAD
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
=======

    public void SetMusicVolume(float silderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(silderValue) * 20);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    public void SetSFXVolume(float silderValue)
    {
<<<<<<< HEAD
        sfxVolume = silderValue;
        mixer.SetFloat("SFXVolume", sfxVolume);
        GlobalAudioControl.AudioInstance.sfxVolume = sfxVolume;
=======
        mixer.SetFloat("SFXVolume", Mathf.Log10(silderValue) * 20);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

}
