using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;

    private AudioSource _interactSound;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        _interactSound = gameObject.GetComponent<AudioSource>();
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
            _interactSound.Play(0);
            _interactCounter = _interactCD;
        }
    }
}
