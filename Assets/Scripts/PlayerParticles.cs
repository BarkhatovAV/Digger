using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayMoveParticles()
    {
        _particleSystem.Play();
    }
}
