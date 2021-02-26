using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6Controller : MonoBehaviour
{
    Transform mainChar;
    GameObject sweat;
    int dialogCounter;
    int dialogTime = 1000;
    DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        mainChar = GameObject.Find("MainChar 3D").transform;
        sweat = GameObject.Find("Sweat");
        dialogCounter = 0;
        dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = mainChar.position;
        if (-9.7 < position.x && position.x < -8.5){
            sweat.SetActive(true);
        }else{
            sweat.SetActive(false);
        }

        if (dialogCounter < dialogTime){
            dialogCounter ++;
            if (dialogCounter >= dialogTime){
                dialogueTrigger.ContinueDialogue();
            }
        }
    }
}
