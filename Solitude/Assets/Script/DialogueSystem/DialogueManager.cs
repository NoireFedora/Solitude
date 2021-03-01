using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{   
    public GameObject mainChar;

    private Queue<string> sentences;
    private Queue<TMP_Text> textContainers;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        textContainers = new Queue<TMP_Text>();
    }

    public void StartDialogue(Dialogue dialogue, bool _thinking)
    {   
        sentences.Clear();
        textContainers.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (TMP_Text textContainer in dialogue.textContainers)
        {
            textContainers.Enqueue(textContainer);
        }

        if (!_thinking)
        {
            mainChar.GetComponent<CharControl>().startTalking();
        }
        else{
            mainChar.GetComponent<CharControl>().startThinking();
        }
        

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        TMP_Text textContainer = textContainers.Dequeue();
        StopAllCoroutines();
        StartCoroutine(ScrollText(sentence, textContainer));

    }

    private IEnumerator ScrollText(string sentence, TMP_Text textContainer)
    {   
         textContainer.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            textContainer.text += letter;
            yield return new WaitForSeconds(0.03f);
        }

    }

    public void EndDialogue()
    {
        mainChar.GetComponent<CharControl>().endTalking();
        mainChar.GetComponent<CharControl>().endThinking();
    }



}
