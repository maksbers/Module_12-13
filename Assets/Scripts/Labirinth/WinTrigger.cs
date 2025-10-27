using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private bool _isTriggered = false;

    public bool IsTriggered => _isTriggered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isTriggered = true;
        }
    }

    public void ResetTrigger()
    {
        _isTriggered = false;
    }
}
