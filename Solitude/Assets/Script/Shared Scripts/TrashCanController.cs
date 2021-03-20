using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanController : MonoBehaviour, ISInteractable
{
    public GameObject mainChar;
    private DialogueTrigger dialogueTrigger;

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
            dialogueTrigger.TriggerDialogue();
        }
        else
        {
            dialogueTrigger.ContinueDialogue();
        }
    }
}
