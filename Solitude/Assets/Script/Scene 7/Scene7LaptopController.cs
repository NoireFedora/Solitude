using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene7LaptopController : MonoBehaviour, ISInteractable
{
    //  private int _interactCD = 0;
    private int _interactCounter;
    private AudioSource _laptopSFX;
    private bool _checkCurtainsOpen;
    private CurtainController _curtainController;
    public AudioSource errorSFX;
    
    private bool _checkLaptop;

    // Start is called before the first frame update
    void Start()
    {
        _laptopSFX = GetComponent<AudioSource>();
        _curtainController = GameObject.FindObjectOfType<CurtainController>();
        _checkLaptop = false;
        

    }

    // Update is called once per frame
    void Update()
    {


        if (_interactCounter > 0)
        {
            _interactCounter--;
        }

    }

    void ISInteractable.interact()
    {
        _checkCurtainsOpen = _curtainController.checkCurtains();

        if (_interactCounter <= 0 && _checkCurtainsOpen)
        {
            _laptopSFX.Play();
            _checkLaptop = true;
        }

        if (_interactCounter <= 0 && !_checkCurtainsOpen) {
            errorSFX.Play();
        }

        _interactCounter += 1;
    }

    public bool InteractedWithLaptop() {
        return _checkLaptop;
    }
}
