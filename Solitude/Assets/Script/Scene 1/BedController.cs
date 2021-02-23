using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BedController : MonoBehaviour, ISInteractable
{
    public GameObject mainChar;
    public Transform speechBalloon;
    public Vector3 newPosition;
    private DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {   
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = Camera.main.WorldToScreenPoint(mainChar.GetComponent<Transform>().position);
        newPosition.y += 120;
        newPosition.x -= 80;
        speechBalloon.position = newPosition;
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
