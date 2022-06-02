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
        _playerCollision.FinalOilStorageCollised += OnFinalOilStorageCollised;
        _playerCollision.NaturalOilDepositCollised += OnNaturalOilDepositCollised;
    }

    private void OnDisable()
    {
        _playerCollision.FinalOilStorageCollised -= OnFinalOilStorageCollised;
        _playerCollision.NaturalOilDepositCollised -= OnNaturalOilDepositCollised;
    }

    private void OnFinalOilStorageCollised(FinalOilStorage finalOilStorage)
    {
        _fuelFillingTime = finalOilStorage.FuelFillingTime;
        finalOilStorage.PourOil(this);
        StartCoroutine(NotifyAboutFuelFilled());
    }

    private void OnNaturalOilDepositCollised(NaturalOilStorage naturalOilDeposit)
    {
        PourOil(naturalOilDeposit);
        StartCoroutine(NotifyAboutFuelFilled());
    }
}
