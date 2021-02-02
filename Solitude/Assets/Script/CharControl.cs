using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{

    private float _playerInputH;
    private float _playerInputV;
    public bool _userJumped = false;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private GameObject _selectedObject;
    Animator animator;

    public bool _grounded = false;
    private bool _moving = true;

    public float handDistance;
    public bool inAction;

    //private float max_speed = 8f;
    // private float max_height = 20f;

    // private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Horizontal", 0);
    }

    // Update is called once per frame
    void Update()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _playerInputV = Input.GetAxis("Vertical");
        _userJumped = Input.GetButton("Jump");

        if (Input.GetButtonDown("Interact") && _selectedObject)
        {
            _selectedObject.GetComponent<InteractController>().interact();
        }
    }

    private void FixedUpdate()
    {
        if (!_moving)
            return;

        // if (_rigidbody.velocity.magnitude < max_speed)
        //{
        //    _rigidbody.velocity += new Vector2(_playerInput * 0.5f, 0);
        //}
        if (!inAction)
        {
            _rigidbody.velocity = new Vector3(_playerInputH * 1f, _rigidbody.velocity.y, _playerInputV * 1f);

            //_grounded = Physics2D.Raycast(transform.position, Vector3.down, 10);
            animator.SetFloat("Horizontal", _playerInputH);

            if (_userJumped)
            {

                if (_grounded)
                {
                    _rigidbody.AddForce(new Vector3(0f, 500f, 0f), ForceMode.Impulse);
                    _userJumped = false;
                    _grounded = false;
                }
            }
        }
        

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
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _grounded = true;
    }

    public void SetMovement(bool moveEnabled)
    {
        _moving = moveEnabled;
        if (!moveEnabled)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

}
