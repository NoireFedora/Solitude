using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1LaptopController : MonoBehaviour, ISInteractable
{
    // private int _interactCD = 0;
    private int _interactCounter;
    private playAudio _gameAudio;
    private AudioSource _laptopSFX;
    private bool _isOpen;

    private GameObject mainChar;
    
    // Start is called before the first frame update
    void Start()
    {
        _laptopSFX = GetComponent<AudioSource>();
        _isOpen = false;
        mainChar = GameObject.Find("New Main Char");

    }

    // Update is called once per frame
    void Update()
    {
        if (_interactCounter > 0)
        {
            _interactCounter--;
        }

    }

    void ISInteractable.interact()
    {
        if (_interactCounter <= 0)
        {   
            mainChar.GetComponent<CharControl>().startListening();
            _laptopSFX.Play();
            _isOpen = true;
        }

        _interactCounter += 1;
    }

    public int InteractedWithLaptop() {
        return _interactCounter;
    }

    public bool IsLaptopOpen() {
        return _isOpen;
    }

}
