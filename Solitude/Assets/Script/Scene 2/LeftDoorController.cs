using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour, ISInteractable
{   
    public Scene2Controller _scene2Controller;

    // Start is called before the first frame update
    void Start()
    {   
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ISInteractable.interact()
    {   
        _scene2Controller.GoNext(true);
    }

}
