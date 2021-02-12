using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{

    private float _playerInputH;
    private float _playerInputV;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private GameObject _selectedObject;
    private GameObject _holdingObject;
    Animator animator;

    public bool _jumped = false;
    public bool _grounded = true;
    public bool _moving = true;
    private bool _talking = false;
    public bool talking { get {return _talking; } }
    private bool _thinking= false;
    public bool thinking { get { return _thinking; } }
    public bool inAction;
    public bool inAnimation;
    public bool can_interact = false;
    public bool weakingUp;

    public float handDistance;

    public GameObject speechGUI;
    public GameObject thoughtGUI;
    public GameObject interactUI;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        inAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _playerInputV = Input.GetAxis("Vertical");
        _jumped = Input.GetButton("Jump");

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
        animator.SetBool("WakeUp", weakingUp);
        
    }

    private void FixedUpdate()
    {   
        if (!_moving)
            return;

        if (!inAction && !inAnimation)
        {
            _rigidbody.velocity = new Vector3(_playerInputH * 1f, _rigidbody.velocity.y, _playerInputV * 1f);
            _transform.position += new Vector3(0, 0.001f, 0); // make player wont stuck on small gap
            animator.SetFloat("Horizontal", _playerInputH);
            animator.SetFloat("Vertical", _playerInputV);

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
                SpriteRenderer interactableRenderer;
                interactableRenderer = interactable.GetComponent<SpriteRenderer>();
                interactableRenderer.sprite = Resources.Load<Sprite>("Element/selected");
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _selectedObject = interactable;
                }
            }

            if (_selectedObject)
            {
                _selectedObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("selected");
                interactUI.SetActive(true);
            }
            else
            {
                interactUI.SetActive(false);
            }
        }
        else
        {   
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            interactUI.SetActive(false);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        _grounded = true;
    }

    public void SetMovement(bool moveEnabled)
    {
        _moving = moveEnabled;

        if (moveEnabled)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (!moveEnabled)
        {   
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
    }

    public void startTalking()
    {
        _talking = true;
        _thinking = false;
        speechGUI.SetActive(_talking);
        thoughtGUI.SetActive(_thinking);
        inAction = true;
        SetMovement(false);
    }

    public void endTalking()
    {
        _talking = false;
        speechGUI.SetActive(_talking);
        inAction = false;
        SetMovement(true);
    }
}
