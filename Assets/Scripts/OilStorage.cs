using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class OilStorage : MonoBehaviour
{
    [SerializeField] private bool _isFull;

    public bool IsFull => _isFull;

    public event UnityAction OilStorageFilled;
    public event UnityAction OilStorageEmptied;

    public void PourOil(OilStorage other)
    {
        if (_isFull == false)
        {
            if (other.TryPourOutOil())
            {
                _isFull = true;
                OilStorageFilled?.Invoke();
            }
        }
    }

    public bool TryPourOutOil()
    {
        if (_isFull == true)
        {
            _isFull = false;
            OilStorageEmptied?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }
}
