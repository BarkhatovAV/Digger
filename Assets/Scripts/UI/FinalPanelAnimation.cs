using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanelAnimation : MonoBehaviour
{
    [SerializeField] private PlayerEventHandler _playerEventHandler;
    [SerializeField] private float _appearanceFinalPanelDelay;

    private Animator _animator;
    private string _animationAppear = "Appear";

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        _playerEventHandler.PlayerFinished += OnPlayerFinished;
    }

    private void OnDisable()
    {
        _playerEventHandler.PlayerFinished -= OnPlayerFinished;
    }

    private void OnPlayerFinished()
    {
        StartCoroutine(FinalPanelAppear());
    }

    private IEnumerator FinalPanelAppear()
    {
        yield return new WaitForSeconds(_appearanceFinalPanelDelay);
        _animator.SetTrigger(_animationAppear);
    }
}
