using LiquidVolumeFX;
using System.Collections;
using UnityEngine;
using TMPro;

public class OilLevelIndicator : MonoBehaviour
{
    [SerializeField] private FinalOilStorage _finalOilStorage;
    [SerializeField] private TMP_Text _text;

    private LiquidVolume _liquidVolume;
    private float _startScore = 25;
    private float _targetScore = 90;

    private void Awake()
    {
        _liquidVolume = _finalOilStorage.GetComponent<LiquidVolume>();
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
        StartCoroutine(RepresentOilLevel());
    }

    private IEnumerator RepresentOilLevel()
    {
        int currentScore = (int)_startScore;
        while (currentScore != _targetScore)
        {
            currentScore = (int)Mathf.Lerp(_startScore, _targetScore, _liquidVolume.level);
            _text.text = currentScore.ToString();
            Vector3 position = transform.position;
            position.y = _liquidVolume.liquidSurfaceYPosition;
            transform.position = position;
            yield return null;
        }
    }
}
