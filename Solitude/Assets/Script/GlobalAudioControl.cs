using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioControl : MonoBehaviour
{
    public float musicVolume;
    public float sfxVolume;

    public static GlobalAudioControl AudioInstance;

    void Awake () {
        if (AudioInstance == null) {
            DontDestroyOnLoad(gameObject);
            AudioInstance = this;
        } else if (AudioInstance != this) {
            Destroy (gameObject);
        }
    }

    public void init () {
        AudioInstance.musicVolume = 1;
        AudioInstance.sfxVolume = 1;
    }

}
