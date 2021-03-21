using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6PimController : PimControl
{
    bool atTargetPosition;

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
        atTargetPosition = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!_moving)
        {
            return;
        }

        if (!_talking)
        {
            // _rigidbody.velocity = new Vector3(0, 0, 0);

            float moveLeft = 0;
            float moveUp = 0;
            if (! atTargetPosition){
                if (transform.position.x > -8.5){
                    moveLeft = -1;
                }

                if (transform.position.z < 1)
                {
                    moveUp = 1;
                }

                if (transform.position.z >= 4.6 && transform.position.x <= -8.5)
                {
                    moveUp = -1;
                    atTargetPosition = true;
                    _footstep.Pause();
                }
            }

            transform.position = new Vector3(moveLeft * speedMultiplier * baseSpeed, 0, moveUp * speedMultiplier * baseSpeed) + transform.position;
            // _rigidbody.MovePosition(position);
            _animator.SetFloat("Horizontal", moveLeft);
            _animator.SetFloat("Vertical", moveUp);

            if (moveLeft < 0)
            {
                if (moveUp < 0) direction = 1f;
                else if (moveUp == 0) direction = 2f;
                else if (moveUp > 0) direction = 3f;
            }
            else if (moveLeft == 0)
            {
                if (moveUp < 0) direction = 0f;
                else if (moveUp > 0) direction = 4f;
            }
            else if (moveLeft > 0)
            {
                if (moveUp < 0) direction = 7f;
                else if (moveUp == 0) direction = 6f;
                else if (moveUp > 0) direction = 5f;
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

    // new public void startListening()
    // {
    //     _talking = true;
    //     SetMovement(false);
    // }
}
