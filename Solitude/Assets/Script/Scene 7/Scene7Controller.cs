using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene7Controller : MonoBehaviour
{
    public Animator bedAnimator;

    private Material _objectLight;
    private float _threshold;

    private Material _interactUI;

    private Scene4LaptopController _laptopController;
    int hasInteracted;
    private bool _checkLights;

    public AudioSource gameAudio;

    private CurtainController _curtainController;
    private bool _checkCurtainsOpen;
    public Animator laptopAnimator;
    private bool _pimDialog = false;
    private bool _hasConversationStarted = false;
    private LightController _lightController;
    public Animator lightsAnimator;
    public Animator curtainAnimator;
    private bool _hasCharFinishedAnim;
    private bool _isCharReady;
    private bool _isCharCorrectPos;

    private CharControl _charControl;
    public Animator charAnimator;

    private bool _isCharFacingDown;
    private bool _hasCharBegunAnim;

    private bool _hasCharEndedAnim;

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
        _interactUI.SetFloat("_Threshold", _threshold);

        _curtainController = GameObject.FindObjectOfType<CurtainController>();
        _hasConversationStarted = false;
        _pimDialog = true;

        _lightController = GameObject.FindObjectOfType<LightController>();
        _hasCharFinishedAnim = false;

        _charControl = GameObject.FindObjectOfType<CharControl>();
        _isCharReady = false;

        _hasCharBegunAnim = false;

        _hasCharEndedAnim = false;

    }

    // Update is called once per frame
    void Update()
    {
        _threshold = _objectLight.GetFloat("_Threshold");
        _checkLights = _threshold == 0;

        if (Input.GetButtonDown("Interact") && !_pimDialog) {
            _pimDialog = gameObject.GetComponent<ConversationTrigger>().ContinueConversation();

            if (_pimDialog) {
                _hasCharEndedAnim = true;
            }

            return;
        }


        _checkCurtainsOpen = _curtainController.checkCurtains();

        if (_checkCurtainsOpen && !lightsAnimator.GetBool("LightOn")) {
            lightsAnimator.SetBool("LightOn", true);
            _charControl.SetMovement(false);
        }

        if (curtainAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpenedCurtainAnimation") && !_hasCharBegunAnim) {
            _charControl.SetMovement(false);
            _isCharReady = true;
            _hasCharBegunAnim = true;
        }

        if (_hasCharFinishedAnim && !_hasConversationStarted) {
            laptopAnimator.SetBool("CurtainsOpened", true);
            gameObject.GetComponent<ConversationTrigger>().TriggerConversation();
            _hasConversationStarted = true;
            _pimDialog = false;
        }
    }

    void FixedUpdate() {

        if (_checkCurtainsOpen && _threshold > 0) {
            _threshold -= 0.01f;
            _lightController.SetThreshold(_threshold);
            _objectLight.SetFloat("_Threshold", _threshold);
            _interactUI.SetFloat("_Threshold", _threshold);
        }

        if (_threshold < 0) {
            _threshold = 0;
            _lightController.SetThreshold(_threshold);
            _objectLight.SetFloat("_Threshold", _threshold);
            _interactUI.SetFloat("_Threshold", _threshold);
        }

        if (_isCharReady) {
            _charControl.SetMovement(false);

            if (!_isCharCorrectPos) {
                charAnimator.SetFloat("LastKey", 0);
                _isCharCorrectPos = true;
            } else {
                charAnimator.SetBool("CurtainOpened", true);
            }

            if (charAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharColouredMovement")) {
                _hasCharFinishedAnim = true;
                _isCharReady = false;
            }

        }

    }

    public bool checkCharEndedAnim() {
        return _hasCharEndedAnim;
    }

    public bool CheckLights() {
        return _checkLights;
    }
}
