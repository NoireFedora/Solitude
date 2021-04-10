using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    private int _haveAppear;
    private bool _checkLights;
    private LightController _lightController;
    private Animator _animator;
    private SpriteRenderer _spiderSprite;
    private bool _checkHorizontal;
    private int _delay;
    private const int _DELAY = 150;
    private int _lightToggle;
    private bool _checkTimer;
    private bool _isAppeared;
    private bool _isStartedAnim;

    // Start is called before the first frame update
    void Start()
    {
        _haveAppear = 0;
         _spiderSprite = gameObject.GetComponent<SpriteRenderer>();
         _spiderSprite.enabled = false;
        _lightController = GameObject.FindObjectOfType<LightController>();
        _animator = GetComponent<Animator>();
        _checkHorizontal = false;
        _delay = _DELAY;
        _lightToggle = 0;
        _checkTimer = false;
        _isAppeared = false;
        _isStartedAnim = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Intermediate State") && _isStartedAnim) {
            _isAppeared = false;
            _isStartedAnim = false;
            _checkHorizontal = false;
            _spiderSprite.enabled = false;
            _checkTimer = false;
            _animator.SetBool("isAnim", false);
        }

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

            if (_checkTimer && !_isAppeared) {

                _spiderSprite.enabled = true;
                _animator.SetBool("isAnim", true);
                _isAppeared = true;
            }

        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Spider Animation")) _isStartedAnim = true;

    }
}
