using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCube : MonoBehaviour
{

    private Animator _animator;
    private bool isClicked = false;
    private bool isShowLog = false;
    private playAudio _gameAudio;
    public AudioSource myAudioSource;

    public GameObject SampleText;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();
        myAudioSource = GetComponent<AudioSource>();
        
        SampleText = GameObject.Find("SampleText");
    }

    void OnMouseDown()
    {   
        isClicked = !(isClicked);
        isShowLog = !(isShowLog);

        if (isClicked) {
            _gameAudio.togglePlay();
            myAudioSource.Play();
            SampleText.SetActive(true);
        }
        else {
            myAudioSource.Stop();
            _gameAudio.togglePlay();
            SampleText.SetActive(false);
        }

        _animator.SetBool("isClicked", isClicked);
    }

}
