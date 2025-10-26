using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField]  private MeshRenderer _meshRenderer;

    private Transform _player;

    [SerializeField] private float _detectionRange = 5;

    private bool _isDead = false;


    private void Update()
    {
        if (_isDead == false)
            return;

        ReadResetCondition();
    }

    private void ReadResetCondition()
    {
        if (IsPlayerOutOfView())
            Reset();
    }

    private void Reset()
    {
        _meshRenderer.enabled = true;

        _isDead = false;

        _player = null;
    }

    private bool IsPlayerOutOfView()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        return distanceToPlayer > _detectionRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isDead)
            return;

        if (other.CompareTag("Player"))
        {
            _player = other.transform;

            Die();
        }
    }

    private void Die()
    {
        _meshRenderer.enabled = false;

        PlayDeadParticles();

        _isDead = true;
    }

    private void PlayDeadParticles()
    {
        Vector3 _emitPosition = transform.position;
        _deathEffect.transform.position = _emitPosition;

        _deathEffect.Play();
    }
}
