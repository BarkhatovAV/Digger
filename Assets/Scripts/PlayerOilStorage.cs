using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollision))]
public class PlayerOilStorage : OilStorage
{
    private PlayerCollision _playerCollision;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
    }

    private void OnEnable()
    {
        _playerCollision.NaturalOilDepositCollised += NaturalOilDepositCollised;
    }

    private void OnDisable()
    {
        _playerCollision.NaturalOilDepositCollised -= NaturalOilDepositCollised;
    }

    private void NaturalOilDepositCollised(NaturalOilDeposit _naturalOilDeposit)
    {
        //Debug.Log("PlayerOilStorage");
        PourOil(_naturalOilDeposit);
    }

}
