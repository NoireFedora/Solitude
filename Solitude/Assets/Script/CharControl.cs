using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{

    private float _playerInputH;
    private float _playerInputV;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private GameObject _selectedObject;
    private GameObject _holdingObject;
    private Animator _animator;
    private AudioSource _footstep;
    private GameObject _interactUI;
    private GameObject _speechBubble;
    //private GameObject _thoughtGUI;
    private GameObject _menu;

    public Animator speechAnimator;

    public bool _jumped;
    public bool _grounded;
    public bool _moving;
    private bool _talking;
    public bool talking { get {return _talking; } }
    private bool _thinking;
    public bool thinking { get { return _thinking; } }
    public bool inAction;
    public bool inAnimation;
    public bool can_interact;
    public bool inMenu;
    public float direction;
    public bool goRightOnly;

    public float handDistance;
    public float speedMultiplier = 1f;
    private float baseSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _footstep = GetComponent<AudioSource>();
        _interactUI = GameObject.Find("InteractUI");
        _speechBubble = GameObject.Find("SpeechBubble");
        _speechBubble.SetActive(false);
        //_thoughtGUI = GameObject.Find("ThoughtGUI");
        _menu = GameObject.Find("Menu");
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 0);
        _jumped = false;
        _grounded = true;
        _moving = true;
        _talking = false;
        _thinking= false;
        inAction = false;
        can_interact = false;
        direction = 0;
        inMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _playerInputV = Input.GetAxis("Vertical");

        if (goRightOnly)
        {   
            if (_playerInputH < 0f)
            {
                _playerInputH = 0f;
            }
        }

        _jumped = Input.GetButton("Jump");

        if (!GetComponent<SpriteRenderer>().isVisible) {
            _footstep.Pause();
            inAnimation = true;
        } else {
            inAnimation = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {   
            if (!inMenu){
                _menu.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }

        if (Input.GetButtonDown("Interact") && _selectedObject)
        {
            _selectedObject.GetComponent<InteractController>().interact();
        }

        if (Input.GetButtonDown("Interact"))
        {
            GameObject[] holdables;
            holdables = GameObject.FindGameObjectsWithTag("Holdable");
            _holdingObject = null;
            float minDistance = handDistance;
            foreach (GameObject holdable in holdables)
            {
                Vector3 diff = holdable.transform.position - _transform.position;
                diff.y = 0f;
                float distance = diff.sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _holdingObject = holdable;
                    
                }
                
            }
            if (_holdingObject)
            {
                _holdingObject.GetComponent<HoldController>().holdStart();
                inAction = true;
            }
        }

        if (Input.GetButtonUp("Interact"))
        {
            if (_holdingObject)
            {
                _holdingObject.GetComponent<HoldController>().holdEnd();
                inAction = false;
                _holdingObject = null;
            }
        }
        
    }

    private void FixedUpdate()
    {   
        if (!_moving) {
            return;
        }

        if (!inAction && !inAnimation)
        {
            // _rigidbody.velocity = new Vector3(_playerInputH * speedMultiplier, _rigidbody.velocity.y, _playerInputV * speedMultiplier);
            // _transform.position += new Vector3(0, -0.005f, 0); // make player wont stuck on small gap
            if (_rigidbody.velocity.y > 0){
                // _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
                _rigidbody.velocity += new Vector3(0, -10f, 0);
            }
            // _transform.position += new Vector3(_playerInputH * speedMultiplier * baseSpeed, 0, _playerInputV * speedMultiplier *baseSpeed);
            
            Vector3 position = new Vector3(_playerInputH * speedMultiplier * baseSpeed, 0, _playerInputV * speedMultiplier * baseSpeed) + _rigidbody.position;
            _rigidbody.MovePosition(position);
            _animator.SetFloat("Horizontal", _playerInputH);
            _animator.SetFloat("Vertical", _playerInputV);

            if (_playerInputH != 0f || _playerInputV != 0f)
            {
                _footstep.UnPause();
            }
            else
            {
                _footstep.Pause();
            }

            // If you find a better way to record the last direction, feel free to edit
            if (_playerInputH < 0)
            {
                if (_playerInputV < 0) direction = 1f;
                else if (_playerInputV == 0) direction = 2f;
                else if (_playerInputV > 0) direction = 3f;
            }
            else if (_playerInputH == 0)
            {   
                if (_playerInputV < 0) direction = 0f;
                else if (_playerInputV > 0) direction = 4f;
            }
            else if (_playerInputH > 0)
            {   
                if (_playerInputV < 0) direction = 7f;
                else if (_playerInputV == 0) direction = 6f;
                else if (_playerInputV > 0) direction = 5f;
            }
            _animator.SetFloat("LastKey", direction);

            // Currently Jump is disabled. Uncomment to enable
            //if (_jumped)
            //{
            //if (_grounded)
            //{
            //_rigidbody.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
            //_jumped = false;
            //_grounded = false;
            //}
            //}

            GameObject[] interactables;
            interactables = GameObject.FindGameObjectsWithTag("Interactable");
            _selectedObject = null;
            float minDistance = handDistance;
            foreach (GameObject interactable in interactables)
            {
                Vector3 diff = interactable.transform.position - _transform.position;
                diff.y = 0f;
                float distance = diff.sqrMagnitude;
                // SpriteRenderer interactableRenderer;
                // interactableRenderer = interactable.GetComponent<SpriteRenderer>();
                // interactableRenderer.sprite = Resources.Load<Sprite>("Element/selected");
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _selectedObject = interactable;
                }
            }

            GameObject[] holdables;
            holdables = GameObject.FindGameObjectsWithTag("Holdable");
            bool inHoldable = false;
            foreach (GameObject holdable in holdables)
            {
                Vector3 diff = holdable.transform.position - _transform.position;
                diff.y = 0f;
                float distance = diff.sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    inHoldable = true;
                }
            }

            if (_selectedObject)
            {
                // _selectedObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("selected");
                _interactUI.SetActive(true);
            }else if(inHoldable){
                _interactUI.SetActive(true);
            }
            else _interactUI.SetActive(false);
        }
        else
        {   
            _animator.SetFloat("Horizontal", 0);
            _animator.SetFloat("Vertical", 0);
            _interactUI.SetActive(false);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        _grounded = true;
    }

    public void SetMovement(bool moveEnabled)
    {
        _moving = moveEnabled;

        if (moveEnabled) _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        if (!moveEnabled)
        {   
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _animator.SetFloat("Horizontal", 0);
            _animator.SetFloat("Vertical", 0);
        }
    }

    public void startTalking()
    {
        _talking = true;
        _thinking = false;
        _speechBubble.SetActive(_talking);
        speechAnimator.SetBool("IsOpen", true);
        //_thoughtGUI.SetActive(_thinking);
        inAction = true;
        SetMovement(false);
    }

    public void endTalking()
    {
        _talking = false;
        _speechBubble.SetActive(_talking);
        inAction = false;
        SetMovement(true);
    }

    public void startThinking()
    {
        _talking = false;
        _thinking = true;
        _speechBubble.SetActive(_talking);
        //_thoughtGUI.SetActive(_thinking);
        inAction = true;
        SetMovement(false);
    }

    public void endThinking()
    {
        _thinking = false;
        //_thoughtGUI.SetActive(_thinking);
        inAction = false;
        SetMovement(true);
    }

    public void CanGoRightOnly(bool boolean)
    {
        goRightOnly = boolean;
    }

}
