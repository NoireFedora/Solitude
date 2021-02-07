using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;
    private playAudio _gameAudio;
    private AudioSource _laptopMusic; 
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        _laptopMusic = GetComponent<AudioSource>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_interactCounter > 0)
        {
            _interactCounter--;
        }

        if(_laptopMusic.time > 5.0f) {
            _laptopMusic.time = 0.0f;
            _laptopMusic.Stop();
            _gameAudio.togglePlay();
         }
    }

    void ISInteractable.interact()
    {
        if (_interactCounter <= 0)
        {
            isOpen = !isOpen;
            _gameAudio.togglePlay();
            _laptopMusic.Play();
            _interactCounter = _interactCD;
        }
    }

    public bool InteractedWithLaptop() {
        return isOpen;
    }
}
