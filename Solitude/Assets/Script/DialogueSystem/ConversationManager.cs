using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationManager : MonoBehaviour
{   
    public GameObject mainChar;
    public GameObject pim;

    public string charName;

    private Queue<string> sentences;
    private Queue<Transform> textContainers;
    private AudioSource scrollSFX;
    private bool BlockMove;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        textContainers = new Queue<Transform>();
        scrollSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        charName = mainChar.GetComponent<CharControl>().charName;
    }

    public void StartConversation(Conversation conversation)
    {   
        sentences.Clear();
        textContainers.Clear();

        foreach (string sentence in conversation.sentences)
        {   
            //Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }
        foreach (Transform textContainer in conversation.textContainers)
        {
            textContainers.Enqueue(textContainer);
        }


        mainChar.GetComponent<CharControl>().startListening();
        pim.GetComponent<PimControl>().startListening();
        
        DisplayNextSentence();

    }

    public void StartConversation(Conversation conversation, bool blockMove)
    {
        sentences.Clear();
        textContainers.Clear();

        foreach (string sentence in conversation.sentences)
        {
            //Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }
        foreach (Transform textContainer in conversation.textContainers)
        {
            textContainers.Enqueue(textContainer);
        }

        if (blockMove){
            mainChar.GetComponent<CharControl>().startListening();
            pim.GetComponent<PimControl>().startListening();
        }
        BlockMove = blockMove;

        DisplayNextSentence();

    }

    public bool DisplayNextSentence()
    {   
        mainChar.GetComponent<CharControl>().DisableInteract(true);

        if (sentences.Count == 0)
        {
            bool isEnded = EndConversation();
            return isEnded;
        }

        string sentence = sentences.Dequeue();
        sentence = sentence.Replace("[name]", charName);
        Transform speechBubble = textContainers.Dequeue();
        speechBubble.gameObject.SetActive(true);
        speechBubble.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
        TMP_Text textContainer = speechBubble.Find("Speech").gameObject.GetComponent<TMP_Text>();
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

    public bool EndConversation()
    {
        StopAllCoroutines();
        mainChar.GetComponent<CharControl>().DisableInteract(false);
        if (BlockMove){
            mainChar.GetComponent<CharControl>().endTalking();
            pim.GetComponent<PimControl>().endTalking();
        }
        return true;
    }



}
