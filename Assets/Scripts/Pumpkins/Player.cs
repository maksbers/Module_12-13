using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _groundLayer = "Ground";

    private string _winTriggerName = "IsWin";
    private string _dieTriggerName = "IsDie";
    private string _resetTriggerName = "Reset";

    [SerializeField] private Animator _animator;
    private Rigidbody _rigidbody;

    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;

    private Vector3 _startPosition;

    private bool _isGrounded = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    private void PlayResetAnimation()
    {
        _animator.SetTrigger(_resetTriggerName);
    }

    public void PlayWinAnimation()
    {
        _animator.SetTrigger(_winTriggerName);
    }

    public void PlayDieAnimation()
    {
        _animator.SetTrigger(_dieTriggerName);
    }

    public void ResetToDefault()
    {
        _rigidbody.isKinematic = false;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;

        PlayResetAnimation();
    }

    public void Lock()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_groundLayer))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_groundLayer))
        {
            _isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return _isGrounded;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void RotateByAxis (Vector3 torqueAxis)
    {
        _rigidbody.AddTorque(torqueAxis * _rotationSpeed, ForceMode.VelocityChange);
    }
}
