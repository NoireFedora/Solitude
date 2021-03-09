using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, ISInteractable
{   
    private GameObject gameChar;

    // Start is called before the first frame update
    void Start()
    {
        gameChar = GameObject.Find("GameChar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {
        gameObject.SetActive(false);
        gameChar.GetComponent<CharControl>()._withTorch = true;
    }
}
