using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // CharControl mainChar = GameObject.Find("MainChar 3D").GetComponent<CharControl>();
        CharControl mainChar = GameObject.Find("New Main Char").GetComponent<CharControl>();
        mainChar.weakingUp = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
