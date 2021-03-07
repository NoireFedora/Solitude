using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollow : MonoBehaviour
{   

    public GameObject speechBackground;
    public GameObject thoughtBackground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 GUIPos = Camera.main.WorldToScreenPoint(this.transform.position);
        if (speechBackground){
            speechBackground.transform.position = GUIPos;
        }
        if (thoughtBackground){
            thoughtBackground.transform.position = GUIPos;
        }
        
    }
}
