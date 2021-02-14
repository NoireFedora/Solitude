using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{   
    public TMP_Text displayText;
    public string fullText;

    CanvasGroup Group;

    // Start is called before the first frame update
    void Start()
    {   
        Group = GetComponent<CanvasGroup>();
        Group.alpha = 0;
        displayText.text = "";
        fullText = "";
    }

    // Update is called once per frame
    void Update()
    {      

    }

    public void ShowText(string text)
    {   
        StopAllCoroutines();
        Group.alpha = 1;
        fullText = text;
        StartCoroutine(AnimateText());
    }

    public void Close()
    {
        StopAllCoroutines();
        Group.alpha = 0;
    }

    private IEnumerator AnimateText()
    {   
         displayText.text = "";

        foreach(char letter in fullText.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

    }

}
