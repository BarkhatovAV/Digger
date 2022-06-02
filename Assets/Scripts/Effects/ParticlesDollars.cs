using System.Collections;
using UnityEngine;

public class ParticlesDollars : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delayGravity;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _particleSystem.Play();
            StartCoroutine(StartGravity());
        }
    }

    private IEnumerator StartGravity()
    {
        yield return new WaitForSeconds(_delayGravity);
        var externalForces = _particleSystem.externalForces;
        externalForces.enabled = true;
    }
}
