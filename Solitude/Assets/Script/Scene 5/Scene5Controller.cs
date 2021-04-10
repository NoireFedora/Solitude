using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene5Controller : MonoBehaviour
{   
    private Material _charLight;
    private Material _wallLight;
    private Material _floorLight;
    private Material _interactUI;
    private float _threshold;

    //public TextMeshProUGUI _interactUI;
    private GameObject _gameChar;
    public Vector3 _gameCharPosition;
    private AudioSource _lightOffSFX;

    public bool lightOff;
    public bool goNext;
    public bool alreadyOff;

    // Start is called before the first frame update
    void Start()
    {
        _charLight = (Material)Resources.Load("Game Char Material", typeof(Material));
        _wallLight = (Material)Resources.Load("Hallway Walls", typeof(Material));
        _floorLight = (Material)Resources.Load("Hallway Floors", typeof(Material));
        _interactUI = (Material)Resources.Load("UIMaterial", typeof(Material));

        _threshold = 0.0f;
        _charLight.SetFloat("_Threshold", _threshold);
        _wallLight.SetFloat("_Threshold", _threshold);
        _floorLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);

        _gameChar = GameObject.Find("GameChar");
        _gameCharPosition = _gameChar.GetComponent<Transform>().position;
        _lightOffSFX = GetComponent<AudioSource>();

        lightOff = false;
        goNext = false;
        alreadyOff = false;
    }

    // Update is called once per frame
    void Update()
    {      
        _gameCharPosition = _gameChar.GetComponent<Transform>().position;
        
        if (_gameCharPosition.x > -48){
            lightOff = true;
        }

        if (lightOff && !alreadyOff){
            _lightOffSFX.Play();
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

        _threshold = 1.0f;
        _charLight.SetFloat("_Threshold", _threshold);
        _wallLight.SetFloat("_Threshold", _threshold);
        _floorLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);
        
        alreadyOff = true;

        //_interactUI.color = Color.white;
        //_interactUI.faceColor = Color.red;

    }

}
