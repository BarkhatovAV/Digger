using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float _decreaseDuration;
    [SerializeField] private float _minScaleMultiplaier;
    [SerializeField] private float _maxScaleMultiplaier;
    [SerializeField] private float _decreaseDelay;

    private float _currentTime;
    private float _scaleMultiplaier;
    private Vector3 _startScale;
    private Vector3 _targetScale = Vector3.zero;
    

    private void Start()
    {
        _scaleMultiplaier = Random.Range(_minScaleMultiplaier, _maxScaleMultiplaier);
        
        transform.localScale *= _scaleMultiplaier;
        _startScale = transform.localScale;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(_decreaseDelay);

        while(_currentTime < _decreaseDuration)
        {
            _currentTime += Time.deltaTime;
            float normalizedTime = _currentTime / _decreaseDuration;
            transform.localScale = Vector3.Lerp(_startScale, _targetScale, normalizedTime);
            yield return null;

        }
        Destroy(this);
    }

}
