using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue
{   
    [TextArea(1, 3)]
    public string[] sentences;
    public TMP_Text[] textContainers;

    public void SetDialogue(string[] newSentences, TMP_Text[] newTextContainers)
    {
        sentences = newSentences;
        textContainers = newTextContainers;
    }

}
