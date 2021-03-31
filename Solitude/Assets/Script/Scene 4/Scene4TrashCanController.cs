using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4TrashCanController : MonoBehaviour, ISInteractable
{

    private Animator _trashCanAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _trashCanAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {   
        _trashCanAnimator.SetBool("HasInteracted", true);
    }
}
