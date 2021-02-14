using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorController : MonoBehaviour, ISInteractable
{   
    public GameObject leftDoor;
    public SceneFade _sceneFade;
    private Material _charLight;
    private Material _wallLight;
    private Material _floorLight;
    private float _charThreshold;
    private float _wallThreshold;
    private float _floorThreshold;

    // Start is called before the first frame update
    void Start()
    {
        _charLight = (Material)Resources.Load("Game Char Material", typeof(Material));
        _wallLight = (Material)Resources.Load("Hallway Walls", typeof(Material));
        _floorLight = (Material)Resources.Load("Hallway Floors", typeof(Material));

        _charThreshold = _charLight.GetFloat("_Threshold");
        _charThreshold = 0.0f;
        _charLight.SetFloat("_Threshold", _charThreshold);

        _wallThreshold =  _wallLight.GetFloat("_Threshold");
        _wallThreshold = 0.0f;
        _wallLight.SetFloat("_Threshold", _wallThreshold);

        _floorThreshold = _floorLight.GetFloat("_Threshold");
        _floorThreshold = 0.0f;
        _floorLight.SetFloat("_Threshold", _floorThreshold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ISInteractable.interact()
    {   
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {   
        _sceneFade.BackGroundControl(true);
        yield return new WaitForSeconds(2.0f);
        leftDoor.SetActive(true);
        gameObject.SetActive(false);

        _charThreshold = 1.0f;
        _charLight.SetFloat("_Threshold", _charThreshold);

        _wallThreshold = 1.0f;
        _wallLight.SetFloat("_Threshold", _wallThreshold);

        _floorThreshold = 1.0f;
        _floorLight.SetFloat("_Threshold", _floorThreshold);

        _sceneFade.BackGroundControl(false);
    }

}
