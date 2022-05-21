using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollision))]
public class PlayerEventHandler : MonoBehaviour
{
    private PlayerCollision _playerCollision;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerCollision.NaturalOilDepositCollised += OnNaturalOilDepositCollised;
        _playerCollision.GroungCollised += OnPlayerGrounded;
    }


    private void OnDisable()
    {
        _playerCollision.NaturalOilDepositCollised -= OnNaturalOilDepositCollised;
        _playerCollision.GroungCollised -= OnPlayerGrounded;
    }

    private void OnPlayerGrounded()
    {
        _playerMover.Land();
        //Debug.Log("OnPlayerGrounded");
    }
    private void OnNaturalOilDepositCollised(NaturalOilDeposit arg0)
    {
        _playerMover.StopMoving();
        //Debug.Log("OnNaturalOilDepositCollised");
    }

}
