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

    public GameObject mainChar;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        _interactSound = gameObject.GetComponent<AudioSource>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
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

    }
}
