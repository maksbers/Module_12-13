using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _forwardKey = KeyCode.W;
    private KeyCode _backwardKey = KeyCode.S;
    private KeyCode _leftKey = KeyCode.A;
    private KeyCode _rightKey = KeyCode.D;

    [SerializeField] private Player _player;
    [SerializeField] private Transform _camera;

    private bool _isJumped = false;
    private bool _isRotatedForward = false;
    private bool _isRotatedBackward = false;
    private bool _isRotatedLeft = false;
    private bool _isRotatedRight = false;


    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        HandleInput();
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(_jumpKey) && _player.IsGrounded())
            _isJumped = true;

        if (Input.GetKey(_forwardKey))
            _isRotatedForward = true;

        if (Input.GetKey(_backwardKey))
            _isRotatedBackward = true;

        if (Input.GetKey(_leftKey))
            _isRotatedLeft = true;

        if (Input.GetKey(_rightKey))
            _isRotatedRight = true;
    }

    private void HandleInput()
    {
        if (_isJumped)
        {
            _player.Jump();
            _isJumped = false;
        }

        if (_isRotatedForward)
        {
            Vector3 torqueAxis = Quaternion.LookRotation(_camera.forward, Vector3.up) * Vector3.right;
            _player.RotateForward(torqueAxis);

            _isRotatedForward = false;
        }

        if (_isRotatedBackward)
        {
            Vector3 torqueAxis = Quaternion.LookRotation(-_camera.forward, Vector3.up) * Vector3.right;
            _player.RotateBackward(torqueAxis);

            _isRotatedBackward = false;
        }

        if (_isRotatedRight)
        {
            Vector3 torqueAxis = Quaternion.LookRotation(_camera.right, Vector3.up) * Vector3.right;
            _player.RotateRight(torqueAxis);

            _isRotatedRight = false;
        }

        if (_isRotatedLeft)
        {
            Vector3 torqueAxis = Quaternion.LookRotation(-_camera.right, Vector3.up) * Vector3.right;
            _player.RotateLeft(torqueAxis);

            _isRotatedLeft = false;
        }
    }
}
