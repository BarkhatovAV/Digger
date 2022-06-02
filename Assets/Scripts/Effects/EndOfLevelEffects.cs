using System.Collections;
using UnityEngine;

public class EndOfLevelEffects : MonoBehaviour
{
    [SerializeField] private PlayerEventHandler _playerEventHandler;
    [SerializeField] private ParticleSystem _confetiParticles;
    [SerializeField] private ParticleSystem _dollarParticles;
    [SerializeField] private float _delayConfetiParticles;
    [SerializeField] private float _delayDollarParticles;
    [SerializeField] private float _delayUsingExternalForces;

    private void OnEnable()
    {
        _playerEventHandler.PlayerFinished += OnFinished;
    }

    private void OnDisable()
    {
        _playerEventHandler.PlayerFinished -= OnFinished;
    }

    private void OnFinished()
    {
        StartCoroutine(PlayEffect());
    }

    private IEnumerator PlayEffect()
    {
        yield return new WaitForSeconds(_delayDollarParticles);
        _dollarParticles.Play();

        yield return new WaitForSeconds(_delayUsingExternalForces);
        var externalForces = _dollarParticles.externalForces;
        externalForces.enabled = true;

        yield return new WaitForSeconds(_delayConfetiParticles);
        _confetiParticles.Play();
    }
}
