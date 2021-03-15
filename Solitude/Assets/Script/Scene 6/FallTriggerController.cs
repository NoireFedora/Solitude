using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerController : MonoBehaviour
{
    Transform mainChar;
    bool inAction;
    int counter;
    public int countMax = 100;
    public float moveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (inAction){
            if (counter < countMax){
                counter ++;
                mainChar.position += new Vector3(moveSpeed, 0,0);
                if (counter >= countMax){
                    CharControl controller = mainChar.GetComponent<CharControl>();
                    controller.SetMovement(true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CharControl controller = other.GetComponent<CharControl>();
        controller.SetMovement(false);
        controller._animator.SetFloat("Horizontal", 1);
        controller._animator.SetFloat("Vertical", 0);
        moveSpeed = controller.getMoveSpeed();
        mainChar = other.transform;

        counter = 0;
        inAction = true;
    }
}
