using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4TrashCanController : MonoBehaviour, ISInteractable
{

    private Animator _trashCanAnimator;
    private AudioSource _trashCanSFX;
    // Start is called before the first frame update
    void Start()
    {
        _trashCanAnimator = GetComponent<Animator>();
        _trashCanSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {   
        _trashCanSFX.Play();
        _trashCanAnimator.SetBool("HasInteracted", true);
    }
}
