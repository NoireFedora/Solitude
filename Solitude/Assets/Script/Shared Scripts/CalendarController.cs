﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalendarController : MonoBehaviour, ISInteractable
{

    public GameObject calendarUI;
    public GameObject mainChar;
    private Animator _charAnimator;
    private Rigidbody _charBody;
    private AudioSource _charAudio;
    public Text calendarText;
    public Text closeButtonText;
    private LightController _lightController;
    private bool _checkLights;
    private int _dayLimit;
    private int _dayCounter;
    private GameObject _nextObject;
    private GameObject _previousObject;
    public Image background;
    public Image closeButton;
    public Outline backgroundOutline;
    public Outline buttonOutline;

    // Start is called before the first frame update
    void Start()
    {
        calendarUI.SetActive(false);
        _charAnimator = mainChar.GetComponent<Animator>();
        _charBody = mainChar.GetComponent<Rigidbody>();
        _charAudio = mainChar.GetComponent<AudioSource>();
        _lightController = GameObject.FindObjectOfType<LightController>();
        _checkLights = _lightController.CheckLights();

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            _dayLimit = 0;
            _dayCounter = 0;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5){
            _dayLimit = 1;
            _dayCounter = 1;
            _nextObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/NextButton").gameObject;
            _previousObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/PreviousButton").gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _checkLights = _lightController.CheckLights();
        if (_checkLights) {
            calendarText.color = Color.white;
            closeButtonText.color = Color.white;
            background.color = Color.black;
            closeButton.color = Color.black;
            backgroundOutline.effectColor = Color.white;
            buttonOutline.effectColor = Color.white;
        } else {
            calendarText.color = Color.black;
            closeButtonText.color = Color.black;
            background.color = Color.white;
            closeButton.color = Color.white;
            backgroundOutline.effectColor = Color.black;
            buttonOutline.effectColor = Color.black;
        }

        if (calendarUI.activeSelf) {
            _charAnimator.enabled = false;
            _charBody.constraints = RigidbodyConstraints.FreezeAll;
            _charAudio.enabled = false;
        }

    }

    public void NextDay() {
        _dayCounter += 1;
        _previousObject.SetActive(true);
        if (_dayCounter == 1) calendarText.text = "DAY 20";

        if (_dayCounter == _dayLimit) _nextObject.SetActive(false); 
    }

    public void PreviousDay() {
        _dayCounter -= 1;
        _nextObject.SetActive(true);

        if (_dayCounter == 0) {
            calendarText.text = "DAY 1";
            _previousObject.SetActive(false);
        }



    }

    public void CloseCalendar() {
        _charAnimator.enabled = true;
        _charBody.constraints = RigidbodyConstraints.FreezeRotation;
        _charAudio.enabled = true;
        calendarUI.SetActive(false);
    }

    void ISInteractable.interact()
    {   
        calendarUI.SetActive(true);        
    }
}