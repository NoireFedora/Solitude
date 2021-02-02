using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour, ISInteractable
{
    public bool isOpen;

    private int _interactCD = 0;
    private int _interactCounter;

    Animator animator;
    public AudioSource interactSound;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
        interactSound = GetComponent<AudioSource>();
        animator.SetBool("IsOpen", isOpen);
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
            isOpen = !isOpen;
            interactSound.Play(0);
            animator.SetBool("IsOpen", isOpen);
            _interactCounter = _interactCD;
        }
    }
}
