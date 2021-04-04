using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;

    private AudioSource _interactSound;
    private DialogueTrigger dialogueTrigger;
    private Animator _curtainAnimator;

    public GameObject mainChar;
    private GameObject _gameAudio;
    private AudioSource _gameAudioSource;
    private Scene7Controller _scene7Controller;
    private bool _checkCharAnim;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        _interactSound = gameObject.GetComponent<AudioSource>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        _curtainAnimator = GetComponent<Animator>();
        _gameAudio = GameObject.FindGameObjectWithTag("GameAudio");
        if (SceneManager.GetActiveScene().buildIndex == 8) {
            _gameAudioSource = _gameAudio.GetComponent<AudioSource>();
            _scene7Controller = GameObject.FindObjectOfType<Scene7Controller>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactCounter > 0)
        {
            _interactCounter--;
        }
    }

    public bool checkCurtains() {
        return isOpen;
    }

    void ISInteractable.interact()
    {

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            if (_interactCounter <= 0)
            {
                _interactSound.Play(0);
                _interactCounter = _interactCD;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 5) {
            if (!mainChar.GetComponent<CharControl>().talking)
            {   
                dialogueTrigger.TriggerDialogue();
            }
            else
            {
                dialogueTrigger.ContinueDialogue();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 8) {

            _checkCharAnim = _scene7Controller.checkCharEndedAnim();

            if (!_checkCharAnim) {
                if (!_gameAudioSource.isPlaying) _gameAudioSource.Play();
                isOpen = true;
                _curtainAnimator.SetBool("isOpened", isOpen);
                _interactCounter = _interactCD;
            } else {
                if (!mainChar.GetComponent<CharControl>().talking) {
                    dialogueTrigger.TriggerDialogue();
                } else {
                    dialogueTrigger.ContinueDialogue();
                }

            }

        }

    }
}
