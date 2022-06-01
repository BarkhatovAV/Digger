using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class OilStorage : MonoBehaviour
{
    [SerializeField] private bool _isFull;
    [SerializeField] protected float _fuelFillingTime;

    public float FuelFillingTime => _fuelFillingTime;


    
    public bool IsFull => _isFull;

    public event UnityAction<float> OilStorageFilled;
    public event UnityAction<float> OilStorageEmptied;
    public event UnityAction FuelFilled;

    public void PourOil(OilStorage other)
    {
        if (_isFull == false)
        {
            if (other.TryPourOutOil())
            {
                _isFull = true;
                OilStorageFilled?.Invoke(FuelFillingTime);
                StartCoroutine(NotifyAboutFuelFilled());
            }
        }
    }

    protected bool TryPourOutOil()
    {
        if (_isFull == true)
        {
            _isFull = false;
            OilStorageEmptied?.Invoke(FuelFillingTime);
            StartCoroutine(NotifyAboutFuelFilled());
            return true;
        }
        else
        {
            return false;
        }
    }

    protected IEnumerator NotifyAboutFuelFilled()
    {
        yield return new WaitForSeconds(FuelFillingTime);
        FuelFilled?.Invoke();
        StopCoroutine(NotifyAboutFuelFilled());
    }
}
