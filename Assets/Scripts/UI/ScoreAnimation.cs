using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Animator _animator;
    private string _animationPulsation = "Pulsation";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _animator.SetBool(_animationPulsation, true);
    }
}
