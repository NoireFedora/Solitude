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
    public Animator _animator;
    private AudioSource[] _audioSource;
    private AudioSource _footstep;
    private AudioSource _bubbleSpawn;
    private GameObject _interactUI;
    private GameObject _speechBubble;
    private GameObject _thoughtBubble;
    private GameObject _menu;
    private GameObject _nameEntry;

    public Animator speechAnimator;
    public Animator thoughtAnimator;

    public bool _jumped;
    public bool _grounded;
    public bool _moving;
    private bool _talking;
    public bool talking { get {return _talking; } }
    private bool _thinking;
    public bool thinking { get { return _thinking; } }
    public bool inAction;
    public bool interactDisabled;
    public bool inAnimation;
    public bool can_interact;
    public bool inMenu;
    public float direction;
    public bool _withTorch;

    public float handDistance;
    public float speedMultiplier = 1f;
    private float baseSpeed = 0.02f;

    public string charName;
    private BedController _bedController;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponents<AudioSource>();
        _footstep = _audioSource[0];
        _bubbleSpawn = _audioSource[1];

        _interactUI = GameObject.Find("InteractUI");
        _speechBubble = gameObject.transform.Find("SpeechBubble").gameObject;
        _speechBubble.SetActive(false);
        _thoughtBubble = gameObject.transform.Find("ThoughtBubble").gameObject;
        _thoughtBubble.SetActive(false);
        _menu = GameObject.Find("Menu");
        _nameEntry = GameObject.Find("NameEntry");
        charName = _nameEntry.GetComponent<NameEntry>().GetPlayerName();
        _nameEntry.SetActive(false);
        _menu.SetActive(false);
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 0);
        _jumped = false;
        _grounded = true;
        _moving = true;
        _talking = false;
        _thinking= false;
        inAction = false;
        interactDisabled = false;
        can_interact = false;
        direction = 0;
        inMenu = false;
        _withTorch = false;

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            _bedController = GameObject.FindObjectOfType<BedController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _playerInputV = Input.GetAxis("Vertical");
        _jumped = Input.GetButton("Jump");

        if (!GetComponent<SpriteRenderer>().isVisible) {
            _footstep.Pause();
            inAnimation = true;
        } 
        else {
            inAnimation = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {   
            if (!inMenu){
                _menu.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }

        if (!interactDisabled){

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
        
    }

    private void FixedUpdate()
    {   
        if (!_moving) {
            return;
        }
        // if (SceneManager.GetActiveScene().buildIndex == 2 && _bedController.checkBedIdle()) {
        //         _interactUI.SetActive(true);
        // }
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

            if ((_playerInputH != 0f || _playerInputV != 0f))
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
            } else if(inHoldable){
                _interactUI.SetActive(true);
            } 
            else _interactUI.SetActive(false);
        }
        else
        {   
            _animator.SetFloat("Horizontal", 0);
            _animator.SetFloat("Vertical", 0);
            _footstep.Pause();
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

        if (moveEnabled) {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _footstep.Play();
        }

        if (!moveEnabled)
        {   
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _animator.SetFloat("Horizontal", 0);
            _animator.SetFloat("Vertical", 0);
            _footstep.Stop();
            if (_holdingObject)
            {
                _holdingObject.GetComponent<HoldController>().holdEnd();
                inAction = false;
                _holdingObject = null;
            }
        }
    }

    public void startTalking()
    {
        _talking = true;
        _thinking = false;
        _footstep.Pause();
        _thoughtBubble.SetActive(_thinking);
        _speechBubble.SetActive(_talking);
        _interactUI.SetActive(false);
        _bubbleSpawn.Play();
        speechAnimator.SetBool("IsOpen", true);
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
        _footstep.Pause();
        _speechBubble.SetActive(_talking);
        _thoughtBubble.SetActive(_thinking);
        _interactUI.SetActive(false);
        _bubbleSpawn.Play();
        thoughtAnimator.SetBool("IsOpen", true);
        inAction = true;
        SetMovement(false);
    }

    public void endThinking()
    {
        _thinking = false;
        _thoughtBubble.SetActive(_thinking);
        inAction = false;
        SetMovement(true);
    }

    public void startListening()
    {
        _talking = true;
        _footstep.Pause();
        inAction = true;
        _interactUI.SetActive(false);
        SetMovement(false);
    }

    public void endListening()
    {
        _talking = false;
        inAction = false;
        SetMovement(true);
    }

    public void DisableInteract(bool boolean){
        interactDisabled = boolean;
    }

    public float getMoveSpeed(){
        return speedMultiplier * baseSpeed;
    }
}
