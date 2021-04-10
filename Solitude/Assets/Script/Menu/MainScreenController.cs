using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenController : MonoBehaviour
{
    void Start()
    {
        GlobalAudioControl.AudioInstance.init();
    }
}
