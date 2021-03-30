using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene7Controller : MonoBehaviour
{
    public Animator bedAnimator;
    public AudioSource errorSFX;

    private Material _objectLight;
    private float _threshold;

    private Material _interactUI;
    private float _UIThreshold;

    private Scene4LaptopController _laptopController;
    int hasInteracted;
    private bool _checkLights;

    public AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        _laptopController = GameObject.FindObjectOfType<Scene4LaptopController>();
        bedAnimator.Play("Base Layer.New BedAnimation", 0, 0);

        _objectLight = (Material)Resources.Load("InvertMaterial", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 1f;
        _objectLight.SetFloat("_Threshold", _threshold);

        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));
        _UIThreshold = _interactUI.GetFloat("_Threshold");
        _UIThreshold = 1.0f;
        _interactUI.SetFloat("_Threshold", _UIThreshold);

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
