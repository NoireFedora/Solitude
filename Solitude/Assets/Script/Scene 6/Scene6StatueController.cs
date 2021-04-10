using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6StatueController : MonoBehaviour, ISInteractable
{   
    public AudioSource statueSFX;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {
        if (!statueSFX.isPlaying) statueSFX.Play();
    }
}
