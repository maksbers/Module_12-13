using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private string _horizontalMouse = "Mouse X";
    private string _verticalMouse = "Mouse Y";

    [SerializeField] private Player _player;

    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _minPitch = -30f;
    [SerializeField] private float _maxPitch = 30f;
    [SerializeField] private float _followSmooth = 5f;

    private float _pitch;
    private float _yaw;


    private void Update()
    {
        FollowToPlayer();
        MouseRotate();
    }

    private void MouseRotate()
    {
        _yaw += Input.GetAxis(_horizontalMouse) * _mouseSensitivity;
        _pitch -= Input.GetAxis(_verticalMouse) * _mouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
    }

    private void FollowToPlayer()
    {
        Vector3 playerPos = _player.transform.position;

        float smoothY = Mathf.Lerp(transform.position.y, playerPos.y, Time.deltaTime * _followSmooth);

        transform.position = new Vector3(playerPos.x, smoothY, playerPos.z);
    }
}