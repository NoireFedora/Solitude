using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Controller : MonoBehaviour
{
    Transform mainChar;
    GameObject sweat;
    int dialogCounter;
    int dialogTime = 1000;
    DialogueTrigger dialogueTrigger;
    private Material _objectLight;
    private float _threshold;
    int hintCounter;
    public int hintCounterMax = 6000;
    bool hinted;
    // Start is called before the first frame update
    void Start()
    {
        _objectLight = (Material)Resources.Load("Game Char Material", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);
        mainChar = GameObject.Find("GameChar").transform;
        sweat = GameObject.Find("Sweat");
        dialogCounter = dialogTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = mainChar.position;
        if (-9.7 < position.x && position.x < -8.5)
        {
            sweat.SetActive(true);
        }
        else
        {
            sweat.SetActive(false);
        }

        // if (dialogCounter < dialogTime)
        // {
        //     dialogCounter++;
        //     if (dialogCounter >= dialogTime)
        //     {
        //         dialogueTrigger.ContinueDialogue();
        //     }
        // }
        if (hinted){
            if (hintCounter<hintCounterMax){
                hintCounter ++;
                if (hintCounter >= hintCounterMax){
                    dialogCounter = 0;
                    dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
                    dialogueTrigger.TriggerDialogue();
                }
            }

            if (dialogCounter < dialogTime)
            {
                dialogCounter++;
                if (dialogCounter >= dialogTime)
                {
                    dialogueTrigger.ContinueDialogue();
                }
            }
        }
    }

    public void startHint(){
        if (!hinted){
            hinted = true;
            hintCounter = 0;
        }
    }
}
