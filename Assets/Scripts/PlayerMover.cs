using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerCollision))]
public class PlayerMover : MonoBehaviour
{
    //[SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _forwardVelocity;
    [SerializeField] private float _horisontalVelocity;

    private PlayerCollision _playerCollision;
    private float _maxDistant = 3f;
    private Vector3 _moveDirection;
    private bool _isRunning = false;
    private PlayerAnimator _playerAnimation;
    private Rigidbody2D _rigidbody2D;
    private bool _isFalling = false;
    

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimator>();
    }


    private void Update()
    {
        //Debug.Log(_rigidbody2D.velocity.y);
        if (_rigidbody2D.velocity.y < -5)
        {
            Fall();
        }
        


        if(_isRunning)
        {
            MoveRight();
        }


    }


    private void Fall()
    {
        if (_isFalling == false)
        {
            _isFalling = true;
            _isRunning = false;
            _playerAnimation.StartFallDownAnimatoin();
        }
    }

    public void Land()
    {
        if(_isFalling == true)
        {
            _isFalling = false;
            _isRunning = true;
            _playerAnimation.EndFallDownAnimatoin();
        }
    }

    private void MoveRight()
    {
        _rigidbody2D.velocity = new Vector2(_horisontalVelocity, _rigidbody2D.velocity.y);
        _playerAnimation.StartRunAnimatoin();
    }

    public void StopMoving()
    {
        _isRunning = false;
        _playerAnimation.StartIdleAnimatoin();
    }
}

        //if (_isRunning)
        //{
        //    RaycastHit hitInfo;
        //    Vector3 down = transform.TransformDirection(Vector3.down);
        //    Ray ray = new Ray(transform.position, down);

        //    if (Physics.Raycast(ray, out hitInfo, _maxDistant/*, _layerMask.value*/))
        //    {
        //        Debug.Log("внизу блок");
        //        //if(hitInfo.transform.TryGetComponent(out DestructibleBlock destructibleBlock))
        //        //{
        //        //    Debug.Log("внизу блок");
        //        //}
        //        //else
        //        //{
        //        Debug.Log("падаю");

        //        //}
        //    }
        //    else
        //    {
        //        Debug.Log("подо мной ничего нет");
        //    }
        //    //if (Physics.Raycast(ray, out hitInfo, _maxDistant, _layerMask.value))
        //    //{
        //    //    _moveDirection = new Vector3( -hitInfo.normal.y, hitInfo.normal.x, 0);
        //    //}

        //    transform.Translate(_moveDirection * _forwardVelocity * Time.deltaTime);

        //}