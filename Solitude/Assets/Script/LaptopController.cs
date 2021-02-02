using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;
    private playAudio _gameAudio;

    public AudioSource laptopMusic; 
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        laptopMusic = GetComponent<AudioSource>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_interactCounter > 0)
        {
            _interactCounter--;
        }

        if(laptopMusic.time > 5.0f) {
            laptopMusic.time = 0.0f;
            laptopMusic.Stop();
            _gameAudio.togglePlay();
         }
    }

    void ISInteractable.interact()
    {
        if (_interactCounter <= 0)
        {
            isOpen = !isOpen;
            _gameAudio.togglePlay();
            laptopMusic.Play();
            _interactCounter = _interactCD;
        }
    }
}
