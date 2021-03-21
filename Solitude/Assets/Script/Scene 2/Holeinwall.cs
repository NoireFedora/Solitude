using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Holeinwall : MonoBehaviour, ISInteractable
{   
    private GameObject gameChar;
    private Transform charPosition;
    private GameObject holeBubble;
    private GameObject smallDoor;
    private GameObject positionHole;
    private Transform dialoguePosition;

    private DialogueLooper dialogueLooper;
    private DialogueTrigger[] dialogueTrigger;

    public Animator holeBubbleAnimator;

    public bool dialogueEnded;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {   
        gameChar = GameObject.Find("GameChar");
        charPosition = gameChar.GetComponent<Transform>();
        holeBubble = GameObject.Find("HoleBubble");
        smallDoor = GameObject.Find("Small Door");
        smallDoor.SetActive(false);
        positionHole = GameObject.Find("Position-Hole");
        dialoguePosition = positionHole.GetComponent<Transform>();
        dialogueLooper = GameObject.FindObjectOfType<DialogueLooper>();
        dialogueTrigger = GetComponents<DialogueTrigger>();
        holeBubbleAnimator.SetBool("IsOpen", true);
        dialogueEnded = false;
        speed = 1f;
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

        bool isTalking = gameChar.GetComponent<CharControl>().talking;

        if (!isTalking && !dialogueEnded)
        {   
            charPosition.position = Vector3.MoveTowards(charPosition.position, dialoguePosition.position, speed);
            dialogueTrigger[0].TriggerDialogue();
        }
        else if (isTalking && !dialogueEnded)
        {   
            StopAllCoroutines();
            dialogueEnded = dialogueTrigger[0].ContinueDialogue();
            if (dialogueEnded)
            {   
                holeBubble.SetActive(false);
                smallDoor.SetActive(true);
            }
        }
        else if (!isTalking && dialogueEnded)
        {
            dialogueTrigger[1].TriggerDialogue();
        }
        else if (isTalking && dialogueEnded)
        {
            dialogueTrigger[1].ContinueDialogue();
        }


    }

}
