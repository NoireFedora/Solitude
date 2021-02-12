using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BedController : MonoBehaviour, ISInteractable
{
    public GameObject mainChar;
    public Transform speechBalloon;
    public TMP_Text speech;
    public Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        speech.text = "I really want to go back to bed…";
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = Camera.main.WorldToScreenPoint(mainChar.GetComponent<Transform>().position);
        newPosition.y += 120;
        newPosition.x -= 80;
        speechBalloon.position = newPosition;
    }

    void ISInteractable.interact()
    {   
        if (!mainChar.GetComponent<CharControl>().talking)
        {
            mainChar.GetComponent<CharControl>().startTalking();
        }
        else
        {
            mainChar.GetComponent<CharControl>().endTalking();
        }
    }

}
