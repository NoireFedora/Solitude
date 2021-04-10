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
<<<<<<< HEAD
    private AudioSource _lightsOffMusic;
=======
    private AudioSource _lightsOffMusic; 
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD

=======
    
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD

        if (_isOpen) {

            if (SceneManager.GetActiveScene().buildIndex == 2) {
                _lightsOffMusic.Stop();
                _gameAudio.togglePlay();
            }
            _lightAnimator.SetBool("LightOn", true);
=======
        
        
        if (_isOpen) {

            if (SceneManager.GetActiveScene().buildIndex == 2) {
                _lightsOffMusic.Stop(); 
                _gameAudio.togglePlay();
            }

            _lightAnimator.SetBool("LightOn", true);
            //_interactUI.color = Color.black;
            //_interactUI.faceColor = Color.black;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

        } else {

            if (SceneManager.GetActiveScene().buildIndex == 2) {
                _gameAudio.togglePlay();
                _lightsOffMusic.Play();
            }
<<<<<<< HEAD
            _lightAnimator.SetBool("LightOn", false);
=======

            _lightAnimator.SetBool("LightOn", false);
            //_interactUI.color = Color.red;
            //_interactUI.faceColor = Color.red;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

        }

        _isOpen = !_isOpen;

    }

    public bool CheckLights() {
        return _isOpen;
    }
<<<<<<< HEAD

=======
    
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    public float GetThreshold() {
        return _threshold;
    }

    public void SetThreshold(float threshold) {
        _threshold = threshold;
    }
<<<<<<< HEAD

    void ISInteractable.interact()
    {
        if (SceneManager.GetActiveScene().buildIndex != 8) {
            if (_interactCounter <= 0)
            {
=======
    
    void ISInteractable.interact()
    {   
        if (SceneManager.GetActiveScene().buildIndex != 8) {
            if (_interactCounter <= 0)
            {   
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD
                    LightOff.Play();
                }

=======
                    LightOff.Play(); 
                }
                
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
                _interactCounter = _interactCD;
            }
        } else {

            if (!mainChar.GetComponent<CharControl>().talking)
<<<<<<< HEAD
            {
=======
            {   
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
                dialogueTrigger.TriggerDialogue();
            }
            else
            {
                dialogueTrigger.ContinueDialogue();
            }
        }
    }
}
