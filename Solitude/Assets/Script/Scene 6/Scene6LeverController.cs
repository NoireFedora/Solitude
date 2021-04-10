using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scene6LeverController : MonoBehaviour, ISHoldable
{
    public GameObject bridgeLeft;
    public GameObject bridgeRight;
    public GameObject fallTrigger;
    public GameObject otherLever;
    private int _holdcounter;
    private int _holdMax;
    private bool _holding;
    public float bridgeSpeed = 0.1f;
    public float bridgeDistance = 2f;
    public bool isFix;
    Animator animator;
    AudioSource activeAudio;
    bool fixDialog = false;
    public AudioSource bridgeExtendingAudio;
    public AudioSource bridgeLockedAudio;
    public AudioSource rockCollidingSFX;
    private bool _isBridgeRetracting;
    // Start is called before the first frame update
    void Start()
    {
        
        _holding = false;
        _holdcounter = 0; 
        _holdMax = (int)(Math.Ceiling(bridgeDistance / bridgeSpeed));
        isFix = false;
        animator = GetComponent<Animator>();
        animator.SetBool("IsDown", false);
        otherLever.GetComponent<Animator>().SetBool("IsDown", false);
        activeAudio = GetComponent<AudioSource>();
        _isBridgeRetracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate() {
        if (isFix)
        {
            return;
        }
        if (_holding)
        {
            if (_holdcounter < _holdMax)
            {
                _holdcounter += 1;
                if(!bridgeExtendingAudio.isPlaying) bridgeExtendingAudio.Play();
                bridgeLeft.transform.position += new Vector3(bridgeSpeed, 0, 0);
                bridgeRight.transform.position -= new Vector3(bridgeSpeed, 0, 0);
                if (fullyExtend())
                {
                    bridgeExtendingAudio.Stop();
                    bridgeLockedAudio.Play();
                    isFix = true;
                    fallTrigger.SetActive(false);
                    gameObject.GetComponent<ConversationTrigger>().TriggerConversation();
                    fixDialog = true;
                }
            }
        }
        else
        {
            if (_holdcounter > 0)
            {
                if(!bridgeExtendingAudio.isPlaying) bridgeExtendingAudio.Play();
                _isBridgeRetracting = true;
                _holdcounter -= 1;
                bridgeLeft.transform.position -= new Vector3(bridgeSpeed, 0, 0);
                bridgeRight.transform.position += new Vector3(bridgeSpeed, 0, 0);
            }

            if (_holdcounter <= 0 && _isBridgeRetracting) {
                bridgeExtendingAudio.Stop();
                rockCollidingSFX.Play();
                _isBridgeRetracting = false;
            }
        }
    }

    public bool fullyExtend()
    {
        return _holdcounter == _holdMax;
    }

    void ISHoldable.holdStart()
    {
        if (fixDialog)
        {
            fixDialog = gameObject.GetComponent<ConversationTrigger>().ContinueConversation();
            return;
        }
        if (isFix){
            gameObject.GetComponent<ConversationTrigger>().ContinueConversation();
            return;
        }
        _holding = true;
        animator.SetBool("IsDown", true);
        otherLever.GetComponent<Animator>().SetBool("IsDown", true);
        activeAudio.Play();
    }

    void ISHoldable.holdEnd()
    {
        if (isFix)
        {
            return;
        }
        _holding = false;
        animator.SetBool("IsDown", false);
        otherLever.GetComponent<Animator>().SetBool("IsDown", false);
        activeAudio.Play();
    }
}
