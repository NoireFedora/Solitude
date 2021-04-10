using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4TrashCanController : MonoBehaviour, ISInteractable
{

    private Animator _trashCanAnimator;
<<<<<<< HEAD
    private AudioSource _trashCanSFX;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    // Start is called before the first frame update
    void Start()
    {
        _trashCanAnimator = GetComponent<Animator>();
<<<<<<< HEAD
        _trashCanSFX = GetComponent<AudioSource>();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {   
<<<<<<< HEAD
        _trashCanSFX.Play();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        _trashCanAnimator.SetBool("HasInteracted", true);
    }
}
