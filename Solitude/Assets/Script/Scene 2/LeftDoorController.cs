using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour, ISInteractable
{   
    public Scene2Controller _scene2Controller;
    public GameObject _interactable;
    private bool canOpen;

    // Start is called before the first frame update
    void Start()
    {   
        canOpen = false;
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
        _interactable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOpen() {
        canOpen = true;
        _interactable.SetActive(true);
    }
    
    void ISInteractable.interact()
    {   
        if (canOpen) {
            _scene2Controller.GoNext(true);
        }
    }

}
