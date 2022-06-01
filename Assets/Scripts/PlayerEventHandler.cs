using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerBezier))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(OilStorage))]
public class PlayerEventHandler : MonoBehaviour
{
    private PlayerCollision _playerCollision;
    private PlayerMover _playerMover;
    private PlayerBezier _playerBezier;
    private OilStorage _playerOilStorage;
    private bool _isFinalOilStorage = false;

    public event UnityAction PlayerFinished;

    private void Awake()
    {
        _playerBezier = GetComponent<PlayerBezier>();
        _playerOilStorage = GetComponent<OilStorage>();
        _playerCollision = GetComponent<PlayerCollision>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerCollision.FinalOilStorageCollised += OnFinalOilStorageCollised;
        _playerOilStorage.FuelFilled += OnFuelFilled;
        _playerCollision.NaturalOilDepositCollised += OnNaturalOilDepositCollised;
        _playerCollision.GroungCollised += OnPlayerGrounded;
    }


    private void OnDisable()
    {
        _playerCollision.FinalOilStorageCollised -= OnFinalOilStorageCollised;
        _playerOilStorage.FuelFilled -= OnFuelFilled;
        _playerCollision.NaturalOilDepositCollised -= OnNaturalOilDepositCollised;
        _playerCollision.GroungCollised -= OnPlayerGrounded;
    }

    private void OnFinalOilStorageCollised(FinalOilStorage finalOilStorage)
    {
        _playerBezier.DrowLine(finalOilStorage.BezierPoint2, finalOilStorage.BezierPoint3);
        _playerMover.StopMoving();
        _isFinalOilStorage = true;
    }

    private void OnFuelFilled()
    {
        _playerBezier.DeleteLine();
        if (_isFinalOilStorage == true)
        {
            PlayerFinished?.Invoke();
            _playerMover.Rotate();
        }
        else
        {
            _playerMover.Run();
        }
    }

    private void OnPlayerGrounded()
    {
        _playerMover.Land();
        //Debug.Log("OnPlayerGrounded");
    }
    private void OnNaturalOilDepositCollised(NaturalOilStorage naturalOilStorage)
    {
        _playerBezier.DrowLine(naturalOilStorage.BezierPoint2, naturalOilStorage.BezierPoint3);
        _playerMover.StopMoving();
        //Debug.Log("OnNaturalOilDepositCollised");
    }

}
