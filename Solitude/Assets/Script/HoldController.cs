﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void holdStart()
    {
        transform.parent.GetComponent<ISHoldable>().holdStart();
    }

    public void holdEnd()
    {
        transform.parent.GetComponent<ISHoldable>().holdEnd();
    }
}
