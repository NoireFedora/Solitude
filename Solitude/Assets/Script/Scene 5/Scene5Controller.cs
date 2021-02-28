using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Controller : MonoBehaviour
{   
    public bool goNext;

    // Start is called before the first frame update
    void Start()
    {
        goNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanGoNext() 
    {
        return goNext; 
    }

    public void GoNext(bool boolean) 
    {
        goNext = boolean; 
    }

}
