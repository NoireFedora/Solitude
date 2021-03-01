using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4LaptopController : MonoBehaviour, ISInteractable
{
    //  private int _interactCD = 0;
    private int _interactCounter;
    private playAudio _gameAudio;
    private AudioSource _laptopSFX;
    private Scene4Controller _scene4Controller;
    private bool _checkLights;
    
    public AudioSource errorSFX;
    // Start is called before the first frame update
    void Start()
    {
        _laptopSFX = GetComponent<AudioSource>();
        _scene4Controller = GameObject.FindObjectOfType<Scene4Controller>();

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
        _checkLights = _scene4Controller.CheckLights();

        if (_interactCounter <= 0 && _checkLights)
        {
            _laptopSFX.Play();
        }

        if (_interactCounter <= 0 && !_checkLights) {
            errorSFX.Play();
        }

        _interactCounter += 1;
    }

    public int InteractedWithLaptop() {
        return _interactCounter;
    }
}
