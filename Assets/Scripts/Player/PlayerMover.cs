using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerParticles))] 
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _horisontalVelocity;

    private PlayerParticles _playerParticles;
    private PlayerAnimator _playerAnimation;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _rotationAngle = new Vector3(0, 180, 0);

    private bool _isRunning = false;
    private bool _isFalling = false;
    private float _runDelay = 0.3f;
    private float _startAnimationDelay = 0.4f;
    private float _rotationDuration = 1f;
    private float _maxVelocity = -6;

    private void Awake()
    {
        _playerParticles = GetComponent<PlayerParticles>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimator>();
    }


    private void Update()
    {
        if (_rigidbody2D.velocity.y < _maxVelocity)
        {
            Fall();
        }

        if(_isRunning)
        {
            MoveRight();
        }
    }

    public void Run()
    {
        StartCoroutine(StartRun());
    }

    private IEnumerator StartRun()
    {
        yield return new WaitForSeconds(_startAnimationDelay);
        _playerAnimation.StartRunAnimatoin();

        yield return new WaitForSeconds(_runDelay);
        _isRunning = true;
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
            StartCoroutine(StartRun());
            _playerAnimation.EndFallDownAnimatoin();
        }
    }

    public void StopMoving()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _isRunning = false;
        _playerAnimation.StartIdleAnimatoin();
    }

    private void MoveRight()
    {
        _rigidbody2D.velocity = new Vector2(_horisontalVelocity, _rigidbody2D.velocity.y /1.2f);
        _playerParticles.PlayMoveParticles();
    }

    public void Rotate()
    {
        transform.DORotate(_rotationAngle, _rotationDuration);
    }
}