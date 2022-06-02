using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerEventHandler))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private string _animationStartFallDown = "FallDownStart";
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
        _animator.SetBool(_animationStartFallDown, true);
    }

    public void EndFallDownAnimatoin()
    {
        _animator.SetBool(_animationStartFallDown, false);
    }

    public void StartRunAnimatoin()
    {
        _animator.SetBool("RunBool", true);
    }

    public void StartIdleAnimatoin()
    {
        _animator.SetBool("RunBool", false);
    }
}
