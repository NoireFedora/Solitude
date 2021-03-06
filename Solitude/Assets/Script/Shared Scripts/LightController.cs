using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour, ISInteractable
{
    private bool _isOpen;

    //public TextMeshProUGUI _interactUI;

    public AudioSource LightOn;
    public AudioSource LightOff;

    private int _interactCD = 0;
    private int _interactCounter;

    private Material _objectLight;
    private float _threshold;

    private Material _interactUI;
    private float _UIThreshold;

    private playAudio _gameAudio;
    private AudioSource _lightsOffMusic;
    private Animator _lightAnimator;

    private DialogueTrigger dialogueTrigger;
    public GameObject mainChar;

    // Start is called before the first frame update
    void Start()
    {
        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");

        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));
        _UIThreshold = _interactUI.GetFloat("_Threshold");

        _lightsOffMusic = GetComponent<AudioSource>();
        _gameAudio = GameObject.FindObjectOfType<playAudio>();

        _lightAnimator = gameObject.GetComponent<Animator>();

        _isOpen = _threshold == 0;

        if (SceneManager.GetActiveScene().buildIndex == 8) {
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }

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

            if (SceneManager.GetActiveScene().buildIndex == 2) {
                _lightsOffMusic.Stop();
                _gameAudio.togglePlay();
            }
            _lightAnimator.SetBool("LightOn", true);

        } else {

            if (SceneManager.GetActiveScene().buildIndex == 2) {
                _gameAudio.togglePlay();
                _lightsOffMusic.Play();
            }
            _lightAnimator.SetBool("LightOn", false);

        }

        _isOpen = !_isOpen;

    }

    public bool CheckLights() {
        return _isOpen;
    }

    public float GetThreshold() {
        return _threshold;
    }

    public void SetThreshold(float threshold) {
        _threshold = threshold;
    }

    void ISInteractable.interact()
    {
        if (SceneManager.GetActiveScene().buildIndex != 8) {
            if (_interactCounter <= 0)
            {
                if (_isOpen) {
                    _threshold = 0.0f;
                    _objectLight.SetFloat("_Threshold", _threshold);
                    _UIThreshold = 0.0f;
                    _interactUI.SetFloat("_Threshold", _UIThreshold);
                    setMode();
                    LightOn.Play();
                } else {
                    _threshold = 1.0f;
                    _objectLight.SetFloat("_Threshold", _threshold);
                    _UIThreshold = 1.0f;
                    _interactUI.SetFloat("_Threshold", _UIThreshold);
                    setMode();
                    LightOff.Play();
                }

                _interactCounter = _interactCD;
            }
        } else {

            if (!mainChar.GetComponent<CharControl>().talking)
            {
                dialogueTrigger.TriggerDialogue();
            }
            else
            {
                dialogueTrigger.ContinueDialogue();
            }
        }
    }
}
