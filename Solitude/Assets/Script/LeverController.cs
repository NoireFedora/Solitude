using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lever1Controller : MonoBehaviour, ISHoldable
{
    public GameObject bridge;
    private int _holdcounter;
    private int _holdMax;
    private bool _holding;
    public float bridgeSpeed = 0.1f;
    public float bridgeDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _holding = false;
        _holdcounter = 0;
        _holdMax = (int)(Math.Ceiling(bridgeDistance / bridgeSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        if (_holding)
        {
            if (_holdcounter < _holdMax)
            {
                _holdcounter += 1;
                bridge.transform.position += new Vector3(bridgeSpeed, 0, 0);
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

    void ISHoldable.holdStart()
    {
        _holding = true;
    }

    void ISHoldable.holdEnd()
    {
        _holding = false;
    }
}
