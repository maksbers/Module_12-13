using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirinthGame : MonoBehaviour
{
    private KeyCode _resetKey = KeyCode.R;

    [SerializeField] private LabirinthControl _labirinthControl;
    [SerializeField] private PlayerBall _playerBall;
    [SerializeField] private WinTrigger _winTrigger;

    private bool _isRunning;


    private void Awake()
    {
        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning == false)
        {
            ReadInputReset();
            return;
        }

        CheckResult();
    }

    private void CheckResult()
    {
        if (_winTrigger.IsTriggered)
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("You win!");
        Pause();
    }

    private void Pause()
    {
        _labirinthControl.Pause();
        _playerBall.Stop();
        _isRunning = false;
    }

    private void ReadInputReset()
    {
        if (Input.GetKeyDown(_resetKey))
        {
            ResetToDefault();
        }
    }

    private void ResetToDefault()
    {
        _winTrigger.ResetTrigger();
        _labirinthControl.ResetRotation();
        _playerBall.ResetPosition();
        _isRunning = true;
    }
}
