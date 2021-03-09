using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene5Controller : MonoBehaviour
{   
    private Material _charLight;
    private Material _wallLight;
    private Material _floorLight;
    private float _charThreshold;
    private float _wallThreshold;
    private float _floorThreshold;

    public TextMeshProUGUI _interactUI;
    private GameObject _gameChar;
    public Vector3 _gameCharPosition;

    public bool lightOff;
    public bool goNext;

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

        _gameChar = GameObject.Find("GameChar");
        _gameCharPosition = _gameChar.GetComponent<Transform>().position;

        lightOff = false;
        goNext = false;
    }

    // Update is called once per frame
    void Update()
    {      
        _gameCharPosition = _gameChar.GetComponent<Transform>().position;
        
        if (_gameCharPosition.x > -48){
            lightOff = true;
        }

        if (lightOff){
            TurnLightOff();
        }
    }

    public bool CanGoNext(){
        return goNext;
    }

    public void GoNext(){
        goNext = true;
    }

    void TurnLightOff(){

        _charThreshold = 1.0f;
        _charLight.SetFloat("_Threshold", _charThreshold);

        _wallThreshold = 1.0f;
        _wallLight.SetFloat("_Threshold", _wallThreshold);

        _floorThreshold = 1.0f;
        _floorLight.SetFloat("_Threshold", _floorThreshold);

        _interactUI.color = Color.white;
        _interactUI.faceColor = Color.red;

    }

}
