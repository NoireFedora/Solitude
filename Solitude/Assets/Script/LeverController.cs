using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeverController : MonoBehaviour, ISHoldable
{
    public GameObject bridge;
    public GameObject otherLever;
    private int _holdcounter;
    private int _holdMax;
    private bool _holding;
    public float bridgeSpeed = 0.1f;
    public float bridgeDistance = 2f;
    public bool isFix;
    Animator animator;
    AudioSource activeAudio;
<<<<<<< HEAD
    public AudioSource bridgeExtendingAudio;
    private bool _isBridgeRetracting;
    public AudioSource rockCollidingSFX;
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
                bridge.transform.position += new Vector3(bridgeSpeed, 0, 0);
                if (fullyExtend())
                {
<<<<<<< HEAD
                    bridgeExtendingAudio.Stop();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
                    LeverController otherLeverController = otherLever.GetComponent<LeverController>();
                    if (otherLeverController.fullyExtend())
                    {
                        isFix = true;
                        otherLeverController.isFix = true;
                    }
<<<<<<< HEAD
                } else {
                    if(!bridgeExtendingAudio.isPlaying) bridgeExtendingAudio.Play();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
                _holdcounter -= 1;
                bridge.transform.position -= new Vector3(bridgeSpeed, 0, 0);
            }

            if (_holdcounter <= 0 && _isBridgeRetracting) {
                bridgeExtendingAudio.Stop();
                rockCollidingSFX.Play();
                _isBridgeRetracting = false;
            }
        }
=======
                _holdcounter -= 1;
                bridge.transform.position -= new Vector3(bridgeSpeed, 0, 0);
            }
        }
        
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    public bool fullyExtend()
    {
        return _holdcounter == _holdMax;
    }

    void ISHoldable.holdStart()
    {
        _holding = true;
        animator.SetBool("IsDown", true);
        activeAudio.Play();
        GameObject.Find("LevelController").GetComponent<Scene3Controller>().startHint();
    }

    void ISHoldable.holdEnd()
    {
        _holding = false;
        animator.SetBool("IsDown", false);
        activeAudio.Play();
    }
}
