using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{   
    public Dialogue dialogue;
    public bool _thinking = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, _thinking);
    }

    public bool ContinueDialogue()
    {
        bool isEnded = FindObjectOfType<DialogueManager>().DisplayNextSentence();
        return isEnded;
    }

    public void SetDialogue(string[] newSentences, TMP_Text[] newTextContainers)
    {
        dialogue.SetDialogue(newSentences, newTextContainers);
    }
}
