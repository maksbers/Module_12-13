using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirinthControl : MonoBehaviour
{
    private KeyCode _leftKey = KeyCode.LeftArrow;
    private KeyCode _rightKey = KeyCode.RightArrow;
    private KeyCode _forwardKey = KeyCode.UpArrow;
    private KeyCode _backwardKey = KeyCode.DownArrow;

    private Rigidbody _rigidbody;

    [SerializeField] private float _speedRotation = 5f;

    private float _tiltX;
    private float _tiltZ;
    private Quaternion _baseRotation;

    private bool _isRunning;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _baseRotation = transform.rotation;

        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning)
        {
            ReadInput();
        }
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void ReadInput()
    {
        if (Input.GetKey(_forwardKey))
            _tiltX += _speedRotation * Time.deltaTime;            

        if (Input.GetKey(_backwardKey))
            _tiltX -= _speedRotation * Time.deltaTime;

        if (Input.GetKey(_leftKey))
            _tiltZ += _speedRotation * Time.deltaTime;

        if (Input.GetKey(_rightKey))
            _tiltZ -= _speedRotation * Time.deltaTime;
    }

    private void Rotate()
    {
        Quaternion target = _baseRotation * Quaternion.Euler(_tiltX, 0f, _tiltZ);
        _rigidbody.MoveRotation(target);
    }

    public void Pause()
    {
        _isRunning = false;
    }

    public void ResetRotation()
    {
        _tiltX = 0f;
        _tiltZ = 0f;

        _isRunning = true;
    }
}
