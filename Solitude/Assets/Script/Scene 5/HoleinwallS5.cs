using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoleinwallS5 : MonoBehaviour, ISInteractable
{
    private GameObject gameChar;
    private GameObject holeBubble;
    private GameObject smallDoor;

    private DialogueLooper dialogueLooper;
    private DialogueTrigger[] dialogueTrigger;

    public Animator holeBubbleAnimator;

    public bool dialogueEnded;
    public bool dialogueEnded2;
    public int count;

    public TMP_Text NPCText;
    private AudioSource scrollSFX;

    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;

    // Start is called before the first frame update
    void Start()
    {   
        gameChar = GameObject.Find("GameChar");
        holeBubble = GameObject.Find("HoleBubble");
        smallDoor = GameObject.Find("Small Door");
        smallDoor.SetActive(false);
        dialogueLooper = GameObject.FindObjectOfType<DialogueLooper>();
        dialogueTrigger = GetComponents<DialogueTrigger>();
        holeBubbleAnimator.SetBool("IsOpen", true);
        dialogueEnded = false;
        dialogueEnded2 = false;
        count = 0;

        torch1.SetActive(false);
        torch2.SetActive(false);
        torch3.SetActive(false);

        scrollSFX = GetComponent<AudioSource>();
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
        bool withTorch = gameChar.GetComponent<CharControl>()._withTorch;

        if (!isTalking && !dialogueEnded)
        {   
            dialogueTrigger[0].TriggerDialogue();
        }
        else if (isTalking && !dialogueEnded)
        {   
            StopAllCoroutines();
            dialogueEnded = dialogueTrigger[0].ContinueDialogue();
            if (dialogueEnded)
            {   
                holeBubble.SetActive(false);
                torch1.SetActive(true);
                torch2.SetActive(true);
                torch3.SetActive(true);
            }
        }
        else if (!isTalking && dialogueEnded && !withTorch)
        {   
            DisplayNPCSentence("I know you can think of some way to break me out.");
        }
        else if (isTalking && dialogueEnded && !withTorch)
        {
            holeBubble.SetActive(false);
            gameChar.GetComponent<CharControl>().endListening();
        }
        // Has bug
        else if (!isTalking && withTorch && count == 0)
        {
            DisplayNPCSentence("You did it! My name is Pim, by the way.");
            smallDoor.SetActive(true);
            torch1.SetActive(false);
            torch2.SetActive(false);
            torch3.SetActive(false);
            count += 1;
        }
        else if (isTalking && withTorch && count == 1)
        {
           dialogueTrigger[1].TriggerDialogue();
           count += 1;
        }
        else if (isTalking && withTorch && count == 2)
        {
            StopAllCoroutines();
            dialogueEnded2 = dialogueTrigger[1].ContinueDialogue();
            if (dialogueEnded2)
            {   
                gameObject.SetActive(false);
                holeBubble.SetActive(false);
            }
        }

    }

    // Functions below is for triggering NPC one time speech
    private IEnumerator ScrollText(string sentence, TMP_Text textContainer)
    {   
        textContainer.text = "";
        yield return new WaitForSeconds(0.3f);
        foreach(char letter in sentence.ToCharArray())
        {   
            scrollSFX.Play();
            textContainer.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.1f);
        gameChar.GetComponent<CharControl>().DisableInteract(false);
    }

    private void DisplayNPCSentence(string sentence)
    {   
        gameChar.GetComponent<CharControl>().startListening();
        holeBubble.SetActive(true);
        holeBubbleAnimator.SetBool("IsOpen", true);
        gameChar.GetComponent<CharControl>().DisableInteract(true);
        TMP_Text textContainer = NPCText;
        StopAllCoroutines();
        StartCoroutine(ScrollText(sentence, textContainer));
    }


}
