using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerEventHandler))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private string _animationStartFallDown = "FallDownStart";
    private string _animationEndFallDown = "FallDownEnd";
    private string _animatoinRun = "Run";
    private string _animatoinIdle = "Idle";
    private string _animationDance = "Dance";
    private PlayerEventHandler _playerEventHandler;

    private void Awake()
    {
        _playerEventHandler = GetComponent<PlayerEventHandler>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerEventHandler.PlayerFinished += OnFinished;
    }

    private void OnDisable()
    {
        _playerEventHandler.PlayerFinished -= OnFinished;
    }

    private void OnFinished()
    {
        _animator.SetTrigger(_animationDance);
    }

    public void StartFallDownAnimatoin()
    {
        //_animator.SetTrigger(_animationStartFallDown);
        _animator.SetBool(_animationStartFallDown, true);
    }

    public void EndFallDownAnimatoin()
    {
        _animator.SetBool(_animationStartFallDown, false);
        //_animator.SetTrigger(_animationEndFallDown);
    }

    public void StartRunAnimatoin()
    {
        //_animator.SetTrigger(_animatoinRun);
        _animator.SetBool("RunBool", true);
    }

    public void StartIdleAnimatoin()
    {
        _animator.SetBool("RunBool", false);
        //_animator.SetTrigger(_animatoinIdle);
    }

    //public void StartClimbAnimation()
    //{
    //    _animator.SetBool(_animationClimbimgName, true);
    //}

    //public void EndClimbAnimation()
    //{
    //    _animator.SetBool(_animationClimbimgName, false);
    //}

    //public void StartFallBackAnimatoin()
    //{
    //    _animator.SetTrigger(_animationFallBackName);
    //}
}
