using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Controller : MonoBehaviour
{
    private Material _objectLight;
    private float _threshold;

    // Start is called before the first frame update
    void Start()
    {
        _objectLight = (Material)Resources.Load("Game Char Material", typeof(Material));
        _threshold = _objectLight.GetFloat("_Threshold");
        _threshold = 0.0f;
        _objectLight.SetFloat("_Threshold", _threshold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
