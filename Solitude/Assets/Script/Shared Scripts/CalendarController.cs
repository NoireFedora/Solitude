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
<<<<<<< HEAD
=======
    private LightController _lightController;
    private bool _checkLights;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    private int _dayLimit;
    private int _dayCounter;
    private GameObject _nextObject;
    private GameObject _previousObject;
    public Image background;
    public Image closeButton;
<<<<<<< HEAD
=======
    public Outline backgroundOutline;
    public Outline buttonOutline;

    private Material _UILight;
    private float _threshold;

>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    private CharControl _charControl;

    public GameObject[] dayObjects;

    // Start is called before the first frame update
    void Start()
    {
        calendarUI.SetActive(false);
<<<<<<< HEAD
        _charControl = GameObject.FindObjectOfType<CharControl>();

        _dayLimit = dayObjects.Length - 1;
        _dayCounter = dayObjects.Length - 1;

=======
        _lightController = GameObject.FindObjectOfType<LightController>();
        _checkLights = _lightController.CheckLights();

        _UILight = (Material)Resources.Load("UIMaterial", typeof(Material));
        _threshold = _lightController.GetThreshold();

        _UILight.SetFloat("Threshold", _threshold);

        _charControl = GameObject.FindObjectOfType<CharControl>();


        _dayLimit = dayObjects.Length - 1;
        _dayCounter = dayObjects.Length - 1;


>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        if (SceneManager.GetActiveScene().buildIndex != 2) {
            _nextObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/NextButton").gameObject;
            _previousObject = gameObject.transform.Find("Calendar UI/Calendar Canvas/PreviousButton").gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        // _checkLights = _lightController.CheckLights();
        // if (_checkLights) {
        //     calendarText.color = Color.white;
        //     closeButtonText.color = Color.white;
        //     background.color = Color.black;
        //     closeButton.color = Color.black;
        //     backgroundOutline.effectColor = Color.white;
        //     buttonOutline.effectColor = Color.white;
        // } else {
        //     calendarText.color = Color.black;
        //     closeButtonText.color = Color.black;
        //     background.color = Color.white;
        //     closeButton.color = Color.white;
        //     backgroundOutline.effectColor = Color.black;
        //     buttonOutline.effectColor = Color.black;
        // }

        _threshold = _lightController.GetThreshold();
        _UILight.SetFloat("_Threshold", _threshold);

>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD
    {
        calendarUI.SetActive(true);
=======
    {   
        calendarUI.SetActive(true);        
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }
}
