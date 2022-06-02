using System.Collections;
using UnityEngine;
using LiquidVolumeFX;

public class OilStorageView : MonoBehaviour
{
    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private OilStorage _oilStorage;
    
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

    private void OnOilStorageEmptied(float fuelFillingTime)
    {
        _liquidVolume.level = _minLiquidVolumeLevel;
        _currentTime = 0;
        StartCoroutine(DecreaseOilLevel(fuelFillingTime));
    }

    private void OnOilStorageFilled(float fuelFillingTime)
    {
        _liquidVolume.level = _maxLiquidVolumeLevel;
        _currentTime = 0;
        StartCoroutine(IncreaseOilLevel(fuelFillingTime));
    }

    private IEnumerator IncreaseOilLevel(float fuelFillingTime)
    {
        while (_currentTime < fuelFillingTime)
        {
            _currentTime += Time.deltaTime;
            float normalizedTime = _currentTime / fuelFillingTime;
            _liquidVolume.level = Mathf.Lerp(_minLiquidVolumeLevel, _maxLiquidVolumeLevel, normalizedTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseOilLevel(float fuelFillingTime)
    {
        while (_currentTime < fuelFillingTime)
        {
            _currentTime += Time.deltaTime;
            float normalizedTime = _currentTime / fuelFillingTime;
            _liquidVolume.level = Mathf.Lerp(_maxLiquidVolumeLevel, _minLiquidVolumeLevel, normalizedTime);
            yield return null;
        }
    }
}
