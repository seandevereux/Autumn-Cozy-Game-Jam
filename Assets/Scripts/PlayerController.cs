using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // simple player controller 2D testing
    Rigidbody2D _rigidbody;

    // Variables
    float walkSpeed = 1.3f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    // Animation handling variables

    string currentAnimation;
    Animator _animator;

    // Constants for anim names

    const string PLAYER_IDLE = "Player Idle";
    const string PLAYER_WALK_LEFT = "Player Walk Left";
    const string PLAYER_WALK_RIGHT = "Player Walk Right";
    const string PLAYER_WALK_UP = "player walk up";
    const string PLAYER_WALK_DOWN = "player walk down";
    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(inputHorizontal != 0 || inputVertical != 0)
        {
            if(inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal = inputHorizontal * speedLimiter;
                inputVertical = inputVertical * speedLimiter;
            }
            _rigidbody.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            } else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }

        } else
        {
            _rigidbody.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void ChangeAnimationState(string animation)
    {
        if(currentAnimation == animation)
        {
            return;
        }

        _animator.Play(animation);

        currentAnimation = animation;
    }
}
