using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerEventHandler _playerEventHandler;
    [SerializeField] private float _increaseScoreDelay;
    [SerializeField] private float _increaseScoreDuration;

    private float _currentTime;
    private float _normalizedTime;
    private int _score;
    private int _initialScore = 25;
    private int _finiteScore = 90;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _playerEventHandler.PlayerFinished += OnPlayerFinished;
    }
    private void OnDisable()
    {
        _playerEventHandler.PlayerFinished -= OnPlayerFinished;
    }

    private void OnPlayerFinished()
    {
        StartCoroutine(IncreaseScore());
    }

    private IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(_increaseScoreDelay);
        while (_currentTime < _increaseScoreDuration)
        {
            _currentTime += Time.deltaTime;
            _normalizedTime = _currentTime / _increaseScoreDuration;
            _score = (int)Mathf.Lerp(_initialScore,_finiteScore, _normalizedTime);
            ScoreChanged?.Invoke(_score);
            yield return null;
        }    
    }
}
