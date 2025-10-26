using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private KeyCode _resetKey = KeyCode.R;

    [SerializeField] private Pocket _pocket;
    [SerializeField] private Player _player;

    [SerializeField] private float _timeLimit = 12f;
    private float _timeRemaining;

    private int _lastLoggedSecond;
    private bool _isRunning = true;


    private void Start()
    {
        _timeRemaining = _timeLimit;
    }

    private void Update()
    {
        ReadInputReset();

        if (_isRunning == false)
            return;

        TimeDecrease();

        CheckResults();

        ShowRemainingTime();
    }

    private void TimeDecrease()
    {
        _timeRemaining -= Time.deltaTime;

        if (_timeRemaining < 0f)
            _timeRemaining = 0f;
    }

    private void ShowRemainingTime()
    {
        int currentSecond = Mathf.FloorToInt(_timeRemaining);

        if (currentSecond != _lastLoggedSecond)
        {
            Debug.Log($"Remain: {currentSecond} sec");
            _lastLoggedSecond = currentSecond;
        }
    }

    private void CheckResults()
    {
        if (_pocket.CollectedCoins >= _pocket.TotalCoins)
        {
            Win();
            Pause();
        }

        else if (_timeRemaining <= 0f)
        {
            GameOver();
            Pause();
        }
    }

    private void Pause()
    {
        _player.Lock();
        _isRunning = false;
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        _player.PlayDieAnimation();

    }

    private void Win()
    {
        Debug.Log("You Win!");
        _player.PlayWinAnimation();
    }

    private void ReadInputReset()
    {
        if (_isRunning == false)
        {
            if (Input.GetKeyDown(_resetKey))
            {
                ResetGame();
            }
        }
    }

    private void ResetGame()
    {
        _player.Reset();

        _pocket.ResetCoins();

        _timeRemaining = _timeLimit;

        _isRunning = true;
    }
}
