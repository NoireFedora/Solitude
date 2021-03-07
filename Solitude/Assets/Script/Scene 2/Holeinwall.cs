using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Holeinwall : MonoBehaviour, ISInteractable
{   
    private GameObject gameChar;
    private GameObject holeBubble;
    private DialogueTrigger dialogueTrigger;
    private CharControl charControl;
    private DialogueLooper dialogueLooper;

    public Animator speechBubble;
    public TMP_Text charText;

    public bool dialogueEnded;

    // Start is called before the first frame update
    void Start()
    {   
        gameChar = GameObject.Find("GameChar");
        holeBubble = GameObject.Find("HoleBubble");
        charControl = gameChar.GetComponent<CharControl>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueLooper = GameObject.FindObjectOfType<DialogueLooper>();
        charControl.CanGoRightOnly(true);
        speechBubble.SetBool("IsOpen", true);
        dialogueEnded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ISInteractable.interact()
    {      
        if (dialogueLooper.GetLooping())
        {
            dialogueLooper.StopLooping();
        }

        if (!gameChar.GetComponent<CharControl>().talking)
        {   
            dialogueTrigger.TriggerDialogue();
        }
        else
        {   
            StopAllCoroutines();
            dialogueEnded = dialogueTrigger.ContinueDialogue();
            if (dialogueEnded)
            {
                holeBubble.SetActive(false);
                string[] newSentences = {"I should let them be..."};
                TMP_Text[] newTextContainers = {charText};
                dialogueTrigger.SetDialogue(newSentences, newTextContainers);
            }
        }

    }

}
