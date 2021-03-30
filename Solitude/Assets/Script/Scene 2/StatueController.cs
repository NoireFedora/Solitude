using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour, ISInteractable
{   
    public GameObject mainChar;
    private DialogueTrigger dialogueTrigger;
    public AudioSource statueSFX;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {   

        if (!mainChar.GetComponent<CharControl>().talking)
        {   
            if (!statueSFX.isPlaying) statueSFX.Play();
            dialogueTrigger.TriggerDialogue();
        }
        else
        {
            dialogueTrigger.ContinueDialogue();
        }
    }
}
