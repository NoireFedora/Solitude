using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Holeinwall : MonoBehaviour, ISInteractable
{   
    public GameObject mainChar;
    public GameObject leftDoor;
    public GameObject holeSpeech;
    public TMP_Text playerSpeech;
    public TMP_Text holeWords;
    public GameObject interactable;
    public Animator animator;
    private DialogueTrigger dialogueTrigger;
    private CharControl charControl;
    private int numTrigger;

    private string[] sentences;
    private TMP_Text[] textContainers;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        charControl = mainChar.GetComponent<CharControl>();
        charControl.goRightOnly = true;
        numTrigger = 0;
        StartCoroutine(ScrollTextZZZ(holeWords));
        animator.SetBool("IsOpen", true);
        sentences = new string[1];
        textContainers = new TMP_Text[1];
        sentences[0] = "I should let them be.";
        textContainers[0] = playerSpeech;
    }

    // Update is called once per frame
    void Update()
    {
        if (numTrigger > 8)
        {
            leftDoor.SetActive(true);
            holeSpeech.SetActive(false);
            charControl.goRightOnly = false;
        }

    }

    void ISInteractable.interact()
    {   
        if (!mainChar.GetComponent<CharControl>().talking || numTrigger == 0)
        {   
            dialogueTrigger.TriggerDialogue();
        }
        else if (numTrigger < 8)
        {   
            StopAllCoroutines();
            dialogueTrigger.ContinueDialogue();
        }
        else
        {   
            dialogueTrigger.dialogue.sentences = sentences;
            dialogueTrigger.dialogue.textContainers = textContainers;
            dialogueTrigger.TriggerDialogue();
            dialogueTrigger.ContinueDialogue();
        }
        numTrigger += 1;
    }

    private IEnumerator ScrollTextZZZ(TMP_Text textContainer)
    {   
        string sentence = "ZZZ...";
        textContainer.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            textContainer.text += letter;
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(ScrollTextZZZ(holeWords));

    }

}
