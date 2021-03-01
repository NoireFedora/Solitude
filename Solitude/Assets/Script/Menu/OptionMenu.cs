using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMusicVolume(float silderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(silderValue) * 20);
    }

    public void SetSFXVolume(float silderValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(silderValue) * 20);
    }

}
