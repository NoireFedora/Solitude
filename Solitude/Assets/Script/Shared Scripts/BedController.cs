using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedController : MonoBehaviour, ISInteractable
{
    public GameObject mainChar;
    public Transform speechBalloon;
    public Vector3 newPosition;
    private DialogueTrigger dialogueTrigger;
    public GameObject bedAnimatorObject;
    private Animator bedAnimator;
    private bool _inBed;
    public GameObject bedInteract;
    private AudioSource _bedSFX;

    // Start is called before the first frame update
    void Start()
    {   
        mainChar.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        bedAnimatorObject.GetComponent<SpriteRenderer>().enabled = true;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        bedAnimator = bedAnimatorObject.GetComponent<Animator>();
        _inBed = true;

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            _bedSFX = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (bedAnimator.GetCurrentAnimatorStateInfo(0).IsName("New BedAnimation")) {
            mainChar.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            bedAnimatorObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (bedAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleBedAnimation") && _inBed) {
            bedInteract.SetActive(true);
            _inBed = true;
        }

        if (Input.GetButtonDown("Interact") && bedAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleBedAnimation")) {
            bedAnimator.SetBool("HasInteracted", true);
            StartCoroutine(PlaySFX());
            bedInteract.SetActive(false);
            _inBed = false;
        }

    }

    public bool checkBedIdle() {
        return _inBed;
    }

    IEnumerator PlaySFX() {
        yield return new WaitForSeconds(1f);
        _bedSFX.Play();
    }

    void ISInteractable.interact()
    {   

        if (bedAnimator.GetCurrentAnimatorStateInfo(0).IsName("New BedAnimation")) {

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

}
