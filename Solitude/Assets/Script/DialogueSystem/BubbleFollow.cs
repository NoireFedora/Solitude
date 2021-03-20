using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollow : MonoBehaviour
{   

    public GameObject interactUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 GUIPos = Camera.main.WorldToScreenPoint(this.transform.position);
        if (interactUI){
            interactUI.transform.position = GUIPos;
        }
        
    }
}
