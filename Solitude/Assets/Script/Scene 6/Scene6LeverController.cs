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
<<<<<<< HEAD
    public AudioSource bridgeExtendingAudio;
    public AudioSource bridgeLockedAudio;
    public AudioSource rockCollidingSFX;
    private bool _isBridgeRetracting;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD
        _isBridgeRetracting = false;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
        
    }

    private void FixedUpdate() {
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        if (isFix)
        {
            return;
        }
        if (_holding)
        {
            if (_holdcounter < _holdMax)
            {
                _holdcounter += 1;
<<<<<<< HEAD
                if(!bridgeExtendingAudio.isPlaying) bridgeExtendingAudio.Play();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
                bridgeLeft.transform.position += new Vector3(bridgeSpeed, 0, 0);
                bridgeRight.transform.position -= new Vector3(bridgeSpeed, 0, 0);
                if (fullyExtend())
                {
<<<<<<< HEAD
                    bridgeExtendingAudio.Stop();
                    bridgeLockedAudio.Play();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD
                if(!bridgeExtendingAudio.isPlaying) bridgeExtendingAudio.Play();
                _isBridgeRetracting = true;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
                _holdcounter -= 1;
                bridgeLeft.transform.position -= new Vector3(bridgeSpeed, 0, 0);
                bridgeRight.transform.position += new Vector3(bridgeSpeed, 0, 0);
            }
<<<<<<< HEAD

            if (_holdcounter <= 0 && _isBridgeRetracting) {
                bridgeExtendingAudio.Stop();
                rockCollidingSFX.Play();
                _isBridgeRetracting = false;
            }
        }
=======
        }
        
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
