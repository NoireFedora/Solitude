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
    private Material _objectLight;
    private float _threshold;

    private Material _interactUI;
<<<<<<< HEAD
=======
    private float _UIThreshold;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

    // Start is called before the first frame update
    void Start()
    {
        _objectLight = (Material)Resources.Load("Game Char Material", typeof(Material));
<<<<<<< HEAD
        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));

        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);

=======
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        mainChar = GameObject.Find("GameChar").transform;
        sweat = GameObject.Find("Sweat");
        dialogCounter = 0;
        dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
<<<<<<< HEAD
=======

        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));
        _UIThreshold = _interactUI.GetFloat("_Threshold");
        _UIThreshold = 0.0f;
        _interactUI.SetFloat("_Threshold", _UIThreshold);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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

        if (position.y < -8){
            mainChar.position = new Vector3(-4f, 1.665f, 0);
        }

        if (dialogCounter < dialogTime){
            dialogCounter ++;
            if (dialogCounter >= dialogTime){
                dialogueTrigger.ContinueDialogue();
            }
        }
    }
}
