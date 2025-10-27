using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startPosition = transform.position;
    }

    public void Stop()
    {
        _rigidbody.isKinematic = true;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        _rigidbody.isKinematic = false;
    }
}
