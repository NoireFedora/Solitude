using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopController : MonoBehaviour, ISInteractable
{
    private int _interactCD = 0;
    private int _interactCounter;
    private playAudio _gameAudio;
    private AudioSource _laptopSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        _laptopSFX = GetComponent<AudioSource>();

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
            _laptopSFX.Play();
            _interactCounter = _interactCD;
        }

        _interactCounter += 1;
    }

    public int InteractedWithLaptop() {
        return _interactCounter;
    }

}
