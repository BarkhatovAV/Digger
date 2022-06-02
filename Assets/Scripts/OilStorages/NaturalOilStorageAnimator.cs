using UnityEngine;

[RequireComponent(typeof(OilStorage))]
[RequireComponent(typeof(Animator))]
public class NaturalOilStorageAnimator : MonoBehaviour
{
    private OilStorage _oilStorage;
    private Animator _animator;
    private string _animationDead = "Dead";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _oilStorage = GetComponent<OilStorage>();
    }

    private void OnEnable()
    {
        _oilStorage.FuelFilled += OnFuelFilled;
    }

    private void OnDisable()
    {
        _oilStorage.FuelFilled += OnFuelFilled;
    }

    private void OnFuelFilled()
    {
        _animator.SetTrigger(_animationDead);
    }
}
