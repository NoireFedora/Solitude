using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{   
    public GameObject mainChar;
    public string charName;

    private Queue<string> sentences;
    private Queue<TMP_Text> textContainers;
    private AudioSource scrollSFX;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        textContainers = new Queue<TMP_Text>();
        scrollSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        charName = mainChar.GetComponent<CharControl>().charName;
    }

    public void StartDialogue(Dialogue dialogue, bool _thinking)
    {   
        sentences.Clear();
        textContainers.Clear();

        foreach (string sentence in dialogue.sentences)
        {   
            //Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }
        foreach (TMP_Text textContainer in dialogue.textContainers)
        {
            textContainers.Enqueue(textContainer);
        }
        
        // Bug: Talking and Thinking cant appear together in one coversation
        // Currently you need to use multiple dialogue triggers to achieve this
        if (!_thinking)
        {
            mainChar.GetComponent<CharControl>().startTalking();
        }
        else{
            mainChar.GetComponent<CharControl>().startThinking();
        }
        
        DisplayNextSentence();

    }

    public bool DisplayNextSentence()
    {   
        mainChar.GetComponent<CharControl>().DisableInteract(true);
        if (sentences.Count == 0)
        {
            bool isEnded = EndDialogue();
            return isEnded;
        }

        string sentence = sentences.Dequeue();
        sentence = sentence.Replace("[name]", charName);
        TMP_Text textContainer = textContainers.Dequeue();
        StopAllCoroutines();
        StartCoroutine(ScrollText(sentence, textContainer));
        return false;
    }

    private IEnumerator ScrollText(string sentence, TMP_Text textContainer)
    {   
        textContainer.text = "";
        yield return new WaitForSeconds(0.3f);
        foreach(char letter in sentence.ToCharArray())
        {   
            scrollSFX.Play();
            textContainer.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.1f);
        mainChar.GetComponent<CharControl>().DisableInteract(false);
    }

    public bool EndDialogue()
    {
        StopAllCoroutines();
        mainChar.GetComponent<CharControl>().DisableInteract(false);
        mainChar.GetComponent<CharControl>().endTalking();
        mainChar.GetComponent<CharControl>().endThinking();
        return true;
    }



}
