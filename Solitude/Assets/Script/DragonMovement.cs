using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{

    private float _playerInput;
    public bool _userJumped = false;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    public bool _grounded = false;
    private bool _moving = true;

    private float max_speed = 8f;
    // private float max_height = 20f;

    // private Animator _animator;
        
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Horizontal");
        _userJumped = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {   
    
        if (!_moving)
            return;

        if (_rigidbody.velocity.magnitude < max_speed)
        {
            _rigidbody.velocity += new Vector2(_playerInput * 0.5f, 0);
        }

        //_grounded = Physics2D.Raycast(transform.position, Vector3.down, 10);

        if (_userJumped)
        {   

            if (_grounded)
            {
                _rigidbody.AddForce(new Vector2(0f, 500f), ForceMode2D.Impulse);
                _userJumped = false;
                _grounded = false;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        _grounded = true;
    }

    public void SetMovement(bool moveEnabled)
    {
        _moving = moveEnabled;
        if (!moveEnabled)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

}
