using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCube : MonoBehaviour
{

    private Animator _animator;
    private bool isClicked = false;
    public playAudio gameAudio;
    public AudioSource myAudioSource;

    void Start()
    {
        _animator = GetComponent<Animator>();
        gameAudio = GameObject.FindObjectOfType<playAudio>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {   
        isClicked = !(isClicked);

        if (isClicked) {
            gameAudio.togglePlay();
            myAudioSource.Play();
        }
        else {
            myAudioSource.Stop();
            gameAudio.togglePlay();
        }

        _animator.SetBool("isClicked", isClicked);
    }

}
