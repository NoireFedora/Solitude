using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{   
    public AudioSource myAudioSource;
    private bool _isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        _isPlaying = false;
        togglePlay();
    }

    public void togglePlay()
    {
        _isPlaying = !(_isPlaying);

        if(_isPlaying) {
            myAudioSource.Play();
        }
        else {
            myAudioSource.Stop();     
        }

    }
}
