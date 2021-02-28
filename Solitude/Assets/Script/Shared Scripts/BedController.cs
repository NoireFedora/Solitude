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
    public GameObject bedAnimator;

    // Start is called before the first frame update
    void Start()
    {   
        mainChar.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        bedAnimator.GetComponent<SpriteRenderer>().enabled = true;
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bedAnimator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New BedAnimation")) {
            mainChar.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            bedAnimator.GetComponent<SpriteRenderer>().enabled = false;
        }


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
