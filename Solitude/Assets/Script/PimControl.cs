using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PimControl : MonoBehaviour
{
    // Movement Parts
    protected float _playerInputH;
    protected float _playerInputV;
    protected Rigidbody _rigidbody;
    public Animator _animator;
    public float speedMultiplier = 1f;
    protected float baseSpeed = 0.02f;

    // Sound Parts
    protected AudioSource[] _audioSource;
    protected AudioSource _footstep;
    protected AudioSource _bubbleSpawn;

    // Speech Bubble Parts
    public GameObject _speechBubble;
    public Animator speechAnimator;

    // Status
    public bool _moving;
    public bool _talking;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponents<AudioSource>();
        _footstep = _audioSource[0];
        _bubbleSpawn = _audioSource[1];
        _speechBubble = GameObject.Find("SpeechBubble-Pim");
        _speechBubble.SetActive(false);
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 0);
        _moving = true;
        _talking = false;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _playerInputV = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        if (!_moving) {
            return;
        }

        if (!_talking)
        {
            if (_rigidbody.velocity.y > 0){
                _rigidbody.velocity += new Vector3(0, -10f, 0);
            }
            
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
        }
        else
        {   
            _animator.SetFloat("Horizontal", 0);
            _animator.SetFloat("Vertical", 0);
            _footstep.Pause();
        }

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
        _footstep.Pause();
        _speechBubble.SetActive(_talking);
        _bubbleSpawn.Play();
        speechAnimator.SetBool("IsOpen", true);
        SetMovement(false);
    }

    public void endTalking()
    {
        _talking = false;
        _speechBubble.SetActive(_talking);
        SetMovement(true);
    }

    public void startListening()
    {
        _talking = true;
        _footstep.Pause();
        SetMovement(false);
    }

    public void endListening()
    {
        _talking = false;
        SetMovement(true);
    }

}
