using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectEffect;

    [SerializeField] private float _rotationSpeed = 50f;

    [SerializeField] private Pocket _pocket;


    private void Update()
    {
        Rotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pocket.AddCoin();

            _collectEffect.transform.position = transform.position;
            _collectEffect.Play();

            Debug.Log("Collected Coins: " + _pocket.CollectedCoins + " from " + _pocket.TotalCoins);

            TurnOff();
        }
    }

    private void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
