using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorControllerS5 : MonoBehaviour, ISInteractable
{
    public Scene5Controller _scene5Controller;

    // Start is called before the first frame update
    void Start()
    {   
        _scene5Controller = GameObject.FindObjectOfType<Scene5Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void ISInteractable.interact()
    {   
        _scene5Controller.GoNext(true);
    }
}
