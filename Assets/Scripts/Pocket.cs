using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;

    private int _totalCoins;
    private int _collectedCoins = 0;

    public int TotalCoins => _totalCoins;
    public int CollectedCoins => _collectedCoins;


    private void Awake()
    {
        _totalCoins = CalculateAllCoins();
    }

    public void ResetCoins()
    {
        ResetCoinsVisibility();
        ResetCollectedCoins();
    }

    private void ResetCoinsVisibility()
    {
        foreach (var coin in _coins)
        {
            coin.TurnOn();
        }
    }

    private void ResetCollectedCoins()
    {
        _collectedCoins = 0;
    }

    public void AddCoin()
    {
        _collectedCoins ++;
    }

    private int CalculateAllCoins()
    {
        return _coins.Count;
    }
}