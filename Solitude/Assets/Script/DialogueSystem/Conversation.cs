using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Conversation
{   
    [TextArea(1, 3)]
    public string[] sentences;
    public Transform[] textContainers;
}
