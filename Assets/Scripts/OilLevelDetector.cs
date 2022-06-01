using LiquidVolumeFX;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OilLevelDetector : MonoBehaviour
{
    [SerializeField] private FinalOilStorage _finalOilStorage;
    [SerializeField] private TMP_Text _text;
    private float _startLiquidSurfaceYPosition;
    private float _endLiquidSurfaceYPosition;
    private LiquidVolume _liquidVolume;
    private float _currentTime = 0;
    private float _minLiquidVolumeLevel = 0;
    private float _maxLiquidVolumeLevel = 1;

    private void Awake()
    {
        _liquidVolume = _finalOilStorage.GetComponent<LiquidVolume>();
        //_liquidVolume.level = 1;
        //_endLiquidSurfaceYPosition = _liquidVolume.liquidSurfaceYPosition;
        //_liquidVolume.level = 0;
        //_startLiquidSurfaceYPosition = _liquidVolume.liquidSurfaceYPosition;

    }

    private void OnEnable()
    {
        _finalOilStorage.OilStorageFilled += OnOilStorageFilled;
    }

    private void OnDisable()
    {
        _finalOilStorage.OilStorageFilled -= OnOilStorageFilled;

    }

    private void OnOilStorageFilled(float fuelFillingTime)
    {
        Debug.Log("OnOilStorageFilled");
        StartCoroutine(FollowOilLevel());
        //StartCoroutine(IncreaseOilLevel(fuelFillingTime));
    }

    private IEnumerator FollowOilLevel()
    {
        while(true)
        {
            //int inr = Mathf.Lerp(_startLiquidSurfaceYPosition,_endLiquidSurfaceYPosition, )
            int inr = (int)Mathf.Lerp(25, 90, _liquidVolume.level);
            _text.text = inr.ToString();
            Vector3 position = transform.position;
            position.y = _liquidVolume.liquidSurfaceYPosition;
            transform.position = position;
            yield return null;

        }
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

}
