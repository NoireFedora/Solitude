using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeController : MonoBehaviour
{

    private int _haveAppear;
    private bool _checkLights;
    private LightController _lightController;
    private Transform _centipedeMovement;
    private Animator _animator;
    private SpriteRenderer _centipedeSprite;
    private bool _checkHorizontal;
    private Vector3 _originalPosition;
    private float _centipedeInput;
    private Rigidbody2D _rigidBody;
    private int _delay;
    private const int _DELAY = 300;
    private AudioSource _centipedeSFX;
    private int _lightToggle;
    private bool _checkTimer;

    // Start is called before the first frame update
    void Start()
    {
        _haveAppear = 0;
         _centipedeSprite = gameObject.GetComponent<SpriteRenderer>();
         _centipedeSprite.enabled = false;
        _lightController = GameObject.FindObjectOfType<LightController>();
        _centipedeMovement = gameObject.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Horizontal", 0);
        _checkHorizontal = false;
        _originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _centipedeInput = 0;
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _delay = _DELAY;
        _centipedeSFX = gameObject.GetComponent<AudioSource>();
        _lightToggle = 0;
        _checkTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        _checkLights = _lightController.CheckLights();

        if (!_checkLights) {
            _lightToggle = 0;
            _delay = _DELAY;
        }

        if (_checkLights && _lightToggle == 0) {
            _checkHorizontal = true;
            _lightToggle = 1;
            _haveAppear = Random.Range(0, 100);
        }

        if (_checkHorizontal && _haveAppear % 2 == 0) {

            if (_delay != 0) _delay -= 1;
            if (_delay == 0) _checkTimer = true;

            if (_checkTimer) {

                if (!_centipedeSFX.isPlaying) _centipedeSFX.Play();
                _centipedeSprite.enabled = true;

                Vector2 position = new Vector2(transform.position.x + 0.03f, transform.position.y);
                _rigidBody.MovePosition(position);

                _centipedeInput += 0.03f;
                _animator.SetFloat("Horizontal", _centipedeInput);

                if (transform.position.x > -19.1f) {
                    _checkHorizontal = false;
                    _centipedeSprite.enabled = false;
                    transform.position = _originalPosition;
                    _centipedeInput = 0;
                    _checkTimer = false;
                    // _haveAppear += 1;
                }
            }

        }

        // if (transform.position.x == _originalPosition.x && !_checkHorizontal && _haveAppear != 0) _haveAppear = Random.Range(0, 1000000000);

    }
}
