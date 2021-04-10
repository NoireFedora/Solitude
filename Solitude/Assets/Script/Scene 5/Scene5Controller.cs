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
<<<<<<< HEAD
    private float _threshold;
=======
    private float _charThreshold;
    private float _wallThreshold;
    private float _floorThreshold;
    private float _UIThreshold;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

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

<<<<<<< HEAD
        _threshold = 0.0f;
        _charLight.SetFloat("_Threshold", _threshold);
        _wallLight.SetFloat("_Threshold", _threshold);
        _floorLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);
=======
        _charThreshold = _charLight.GetFloat("_Threshold");
        _charThreshold = 0.0f;
        _charLight.SetFloat("_Threshold", _charThreshold);

        _wallThreshold =  _wallLight.GetFloat("_Threshold");
        _wallThreshold = 0.0f;
        _wallLight.SetFloat("_Threshold", _wallThreshold);

        _floorThreshold = _floorLight.GetFloat("_Threshold");
        _floorThreshold = 0.0f;
        _floorLight.SetFloat("_Threshold", _floorThreshold);

        _UIThreshold = _interactUI.GetFloat("_Threshold");
        _UIThreshold = 0.0f;
        _interactUI.SetFloat("_Threshold", _UIThreshold);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

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

<<<<<<< HEAD
        _threshold = 1.0f;
        _charLight.SetFloat("_Threshold", _threshold);
        _wallLight.SetFloat("_Threshold", _threshold);
        _floorLight.SetFloat("_Threshold", _threshold);
        _interactUI.SetFloat("_Threshold", _threshold);
=======
        _charThreshold = 1.0f;
        _charLight.SetFloat("_Threshold", _charThreshold);

        _wallThreshold = 1.0f;
        _wallLight.SetFloat("_Threshold", _wallThreshold);

        _floorThreshold = 1.0f;
        _floorLight.SetFloat("_Threshold", _floorThreshold);

        _UIThreshold = 1.0f;
        _interactUI.SetFloat("_Threshold", _UIThreshold);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        
        alreadyOff = true;

        //_interactUI.color = Color.white;
        //_interactUI.faceColor = Color.red;

    }

}
