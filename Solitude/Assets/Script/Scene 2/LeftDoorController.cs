using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour, ISInteractable
{   
    public Scene2Controller _scene2Controller;
    private bool canOpen;

    // Start is called before the first frame update
    void Start()
    {   

        canOpen = false;
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOpen() {
        canOpen = true;
    }
    
    void ISInteractable.interact()
    {   
        if (canOpen) {
            _scene2Controller.GoNext(true);
        }
    }

}
