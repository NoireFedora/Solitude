using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{   
    public Dialogue dialogue;
    public bool _thinking = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, _thinking);
    }

    public void ContinueDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
