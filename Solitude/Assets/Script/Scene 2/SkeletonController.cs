using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour, ISInteractable
{
    private AudioSource _skeletonSFX;
    // Start is called before the first frame update
    void Start()
    {
        _skeletonSFX = GetComponent<AudioSource>();
    }

    void ISInteractable.interact()
    {   
        if(!_skeletonSFX.isPlaying) _skeletonSFX.Play();
        
    }
}
