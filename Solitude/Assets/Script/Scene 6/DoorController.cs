using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, ISInteractable
{
    private AudioSource _doorSFX;
    private Animator _doorAnimator;
    private bool _doorOpened;
    private GameObject mainChar;

    // Start is called before the first frame update
    void Start()
    {
        _doorSFX = GetComponent<AudioSource>();
        _doorAnimator = GetComponent<Animator>();
        _doorOpened = false;
        mainChar = GameObject.Find("GameChar");
    }

    public bool checkDoor(){
        return _doorOpened;
    }

    // Update is called once per frame
    void ISInteractable.interact()
    {
        _doorSFX.Play();
        _doorOpened = true;
        _doorAnimator.SetBool("CanOpen", _doorOpened);
        mainChar.GetComponent<CharControl>().startListening();
    }
}
