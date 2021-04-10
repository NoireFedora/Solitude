using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Controller : MonoBehaviour
{

    public Animator bedAnimator;
    public AudioSource errorSFX;
    public AudioSource laptopSFX;

    private Material _objectLight;
<<<<<<< HEAD
    private Material _interactUI;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    private float _threshold;

    private Scene4LaptopController _laptopController;
    int hasInteracted;
    private bool _checkLights;

    // Start is called before the first frame update
    void Start()
    {
        _laptopController = GameObject.FindObjectOfType<Scene4LaptopController>();
        bedAnimator.Play("Base Layer.New BedAnimation", 0, 0);

        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
<<<<<<< HEAD
        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));
        _threshold = 1f;
        _objectLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);
=======
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 1f;
        _objectLight.SetFloat("_Threshold", _threshold);

        

>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    // Update is called once per frame
    void Update()
    {
        _threshold = _objectLight.GetFloat("_Threshold");
        _checkLights = _threshold == 0;

    }

    public bool CheckLights() {
        return _checkLights;
    }
}
