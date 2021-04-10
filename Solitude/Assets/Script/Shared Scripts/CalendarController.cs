using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalendarController : MonoBehaviour, ISInteractable
{

    public GameObject calendarUI;
    public Text calendarText;
    public Text closeButtonText;
    private int _dayLimit;
    private int _dayCounter;
    private GameObject _nextObject;
    private GameObject _previousObject;
    public Image background;
    public Image closeButton;
    private CharControl _charControl;

    public GameObject[] dayObjects;

    // Start is called before the first frame update
    void Start()
    {
        calendarUI.SetActive(false);
        _charControl = GameObject.FindObjectOfType<CharControl>();

        _dayLimit = dayObjects.Length - 1;
        _dayCounter = dayObjects.Length - 1;

        if (SceneManager.GetActiveScene().buildIndex != 2) {
            _nextObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/NextButton").gameObject;
            _previousObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/PreviousButton").gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (calendarUI.activeSelf) {
            _charControl.SetMovement(false);
        }

    }

    public void NextDay() {
        dayObjects[_dayCounter].SetActive(false);
        _dayCounter += 1;
        dayObjects[_dayCounter].SetActive(true);
        _previousObject.SetActive(true);
        if (_dayCounter == _dayLimit) _nextObject.SetActive(false);
    }

    public void PreviousDay() {
        dayObjects[_dayCounter].SetActive(false);
        _dayCounter -= 1;
        dayObjects[_dayCounter].SetActive(true);
        _nextObject.SetActive(true);
        if (_dayCounter == 0) {
            _previousObject.SetActive(false);
        }



    }

    public void CloseCalendar() {
        _charControl.SetMovement(true);
        calendarUI.SetActive(false);
    }

    void ISInteractable.interact()
    {
        calendarUI.SetActive(true);
    }
}
