using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : MonoBehaviour
{

    private Material _objectLight;
    private Material _interactUI;
    private float _threshold;
<<<<<<< HEAD
=======
    private float _UIThreshold;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

    public AudioSource laptopSFX;
    private Scene1LaptopController _laptopController;
    int hasInteracted;

    // Start is called before the first frame update
    void Start()
    {

        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
<<<<<<< HEAD
=======
        _threshold = _objectLight.GetFloat("_Threshold");
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);

        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));
<<<<<<< HEAD
        _interactUI.SetFloat("_Threshold", _threshold);
=======
        _UIThreshold = _interactUI.GetFloat("_Threshold");
        _UIThreshold = 0.0f;
        _interactUI.SetFloat("_Threshold", _UIThreshold);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

        _laptopController = GameObject.FindObjectOfType<Scene1LaptopController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
