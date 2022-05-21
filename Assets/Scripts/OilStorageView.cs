using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
using System;
using UnityEngine.Events;
using DG.Tweening;

public class OilStorageView : MonoBehaviour
{
    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private OilStorage _oilStorage;
    [SerializeField] private float _fuelFillingTime;

    private float _maxLiquidVolumeLevel = 1;
    private float _minLiquidVolumeLevel = 0;
    private float _currentTime;

    private void Start()
    {
        if (_oilStorage.IsFull)
            _liquidVolume.level = _maxLiquidVolumeLevel;
        else
            _liquidVolume.level = _minLiquidVolumeLevel;
    }

    private void OnEnable()
    {
        _oilStorage.OilStorageFilled += OnOilStorageFilled;
        _oilStorage.OilStorageEmptied += OnOilStorageEmptied;
    }

    private void OnDisable()
    {
        _oilStorage.OilStorageFilled -= OnOilStorageFilled;
        _oilStorage.OilStorageEmptied -= OnOilStorageEmptied;
    }

    private void OnOilStorageEmptied()
    {
        _liquidVolume.level = _minLiquidVolumeLevel;
        _currentTime = 0;
        StartCoroutine(DecreaseOilLevel());
    }

    private void OnOilStorageFilled()
    {
        _liquidVolume.level = _maxLiquidVolumeLevel;
        _currentTime = 0;
        StartCoroutine(IncreaseOilLevel());
    }

    private IEnumerator IncreaseOilLevel()
    {
        while (_currentTime < _fuelFillingTime)
        {
            _currentTime += Time.deltaTime;
            float normalizedTime = _currentTime / _fuelFillingTime;
            _liquidVolume.level = Mathf.Lerp(_minLiquidVolumeLevel, _maxLiquidVolumeLevel, normalizedTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseOilLevel()
    {
        while (_currentTime < _fuelFillingTime)
        {
            _currentTime += Time.deltaTime;
            float normalizedTime = _currentTime / _fuelFillingTime;
            _liquidVolume.level = Mathf.Lerp(_maxLiquidVolumeLevel, _minLiquidVolumeLevel, normalizedTime);
            yield return null;
        }
    }

}
