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
    // Start is called before the first frame update
    void Start()
    {
        
        _holding = false;
        _holdcounter = 0;
        _holdMax = (int)(Math.Ceiling(bridgeDistance / bridgeSpeed));
        isFix = false;
        animator = GetComponent<Animator>();
        animator.SetBool("IsDown", false);

    }

    // Update is called once per frame
    void Update()
    {
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
                    LeverController otherLeverController = otherLever.GetComponent<LeverController>();
                    if (otherLeverController.fullyExtend())
                    {
                        isFix = true;
                        otherLeverController.isFix = true;
                    }
                }
            }
        }
        else
        {
            if (_holdcounter > 0)
            {
                _holdcounter -= 1;
                bridge.transform.position -= new Vector3(bridgeSpeed, 0, 0);
            }
        }
        
    }

    public bool fullyExtend()
    {
        return _holdcounter == _holdMax;
    }

    void ISHoldable.holdStart()
    {
        _holding = true;
        animator.SetBool("IsDown", true);
    }

    void ISHoldable.holdEnd()
    {
        _holding = false;
        animator.SetBool("IsDown", false);
    }
}
