using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;

    private Material _objectLight;
    private float _threshold;

    private playAudio _gameAudio;
    private AudioSource _lightsOffMusic; 

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);

        _lightsOffMusic = GetComponent<AudioSource>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();


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
            if (isOpen) {
                _threshold = 0.0f;
                _objectLight.SetFloat("_Threshold", _threshold);
                _lightsOffMusic.Stop(); 
                _gameAudio.togglePlay();
                isOpen = !isOpen;    
            } else {
                _threshold = 1.0f;
                _objectLight.SetFloat("_Threshold", _threshold);
                _gameAudio.togglePlay();
                _lightsOffMusic.Play();  
                isOpen = !isOpen; 
            }
            _interactCounter = _interactCD;
        }
    }
}
