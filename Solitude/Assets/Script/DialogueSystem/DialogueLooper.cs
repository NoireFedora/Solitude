using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLooper : MonoBehaviour
{
    public string sentence;
    public TMP_Text textContainer;
    public bool looping;

    // Start is called before the first frame update
    void Start()
    {   
        looping = true;
        StartCoroutine(ScrollTextLoop(sentence, textContainer));
    }

    void Update()
    {
        if (!looping)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ScrollTextLoop(string sentence, TMP_Text textContainer)
    {   
        textContainer.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            textContainer.text += letter;
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(ScrollTextLoop(sentence, textContainer));

    }

    public void StopLooping(){
        looping = false;
    }

    public bool GetLooping(){
        return looping;
    }

}
