using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightController : MonoBehaviour, ISInteractable
{
    private bool _isOpen;

    public TextMeshProUGUI _interactUI;

    public AudioSource LightOn;
    public AudioSource LightOff;

    private int _interactCD = 0;
    private int _interactCounter;

    private Material _objectLight;
    private float _threshold;

    private playAudio _gameAudio;
    private AudioSource _lightsOffMusic; 
    private Animator _lightAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");
    
        _lightsOffMusic = GetComponent<AudioSource>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();

        _lightAnimator = gameObject.GetComponent<Animator>();

        _isOpen = _threshold == 0;

        setMode();


    }

    // Update is called once per frame
    void Update()
    {
        if (_interactCounter > 0)
        {
            _interactCounter--;
        }

    }

    void setMode() {
        
        
        if (_isOpen) {
            _lightsOffMusic.Stop(); 
            _gameAudio.togglePlay();
            _lightAnimator.SetBool("LightOn", true);
            _interactUI.color = Color.black;
            _interactUI.faceColor = Color.black;
        } else {
            _gameAudio.togglePlay();
            _lightsOffMusic.Play();  
            _lightAnimator.SetBool("LightOn", false);
            _interactUI.color = Color.red;
            _interactUI.faceColor = Color.red;
        }

        _isOpen = !_isOpen;

    }

    void ISInteractable.interact()
    {   
        
        if (_interactCounter <= 0)
        {   
            if (_isOpen) {
                _threshold = 0.0f;
                _objectLight.SetFloat("_Threshold", _threshold);
                setMode();
                LightOn.Play();
            } else {
                _threshold = 1.0f;
                _objectLight.SetFloat("_Threshold", _threshold);
                setMode();
                LightOff.Play(); 
            }
            
            _interactCounter = _interactCD;
        }
    }
}
