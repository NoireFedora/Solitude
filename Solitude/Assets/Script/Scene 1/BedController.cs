using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BedController : MonoBehaviour, ISInteractable
{
    public GameObject mainChar;
    public DialogueController _dialogueController;
    public Transform speechBalloon;
    public Vector3 newPosition;

    public int numSentence;
    public int numInteract;
    public string text;
    public string text2;

    // Start is called before the first frame update
    void Start()
    {   
        numSentence = 2;
        numInteract = 0;
        text = "I really want to go back to bed...";
        text2 = "However, time to play game";
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
            mainChar.GetComponent<CharControl>().startTalking();
            _dialogueController.ShowText(text);
            numInteract++;
        }
        else if (mainChar.GetComponent<CharControl>().talking && numInteract < numSentence)
        {
            _dialogueController.ShowText(text2);
            numInteract++;
        }
        else
        {
            _dialogueController.Close();
            mainChar.GetComponent<CharControl>().endTalking();
            numInteract = 0;
        }
    }

}
