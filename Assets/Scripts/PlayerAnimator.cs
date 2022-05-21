using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private string _animationStartFallDown = "FallDownStart";
    private string _animationEndFallDown = "FallDownEnd";
    private string _animatoinRun = "Run";
    private string _animatoinIdle = "Idle";

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        _animator.SetTrigger(_animatoinRun);
    }

    public void StartIdleAnimatoin()
    {
        _animator.SetTrigger(_animatoinIdle);
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
