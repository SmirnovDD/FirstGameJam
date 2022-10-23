using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private float _openToAngle = 210f;
    [SerializeField] private float _openSpeed = 5f;
    [SerializeField] private float _closeAfter = 3f;
    private float _timer;
    private Quaternion _defaultRotation;
    private Quaternion _openRotation;
    private bool _triggered;
    private bool _opened;
    private float _elapsedTime;
    private void Awake()
    {
        _defaultRotation = transform.rotation;
        _openRotation = Quaternion.Euler(_defaultRotation.eulerAngles.x, _openToAngle, _defaultRotation.eulerAngles.z);
    }

    [ContextMenu("Trigger")]
    public void Trigger()
    {
        _timer = _closeAfter;
        _triggered = true;
    }

    private void Update()
    {
        if (!_triggered)
            return;

        if (!_opened)
            transform.rotation = Quaternion.Lerp(_defaultRotation, _openRotation, _elapsedTime / _openSpeed);
        else
        {
            transform.rotation = Quaternion.Lerp(_openRotation, _defaultRotation, _elapsedTime / _openSpeed);
            if (_elapsedTime / _openSpeed >= 1)
                Destroy(this);
        }
            
        _timer -= Time.deltaTime;
        _elapsedTime += Time.deltaTime;

        if (_timer <= 0)
        {
            _opened = true;
            _timer = _closeAfter;
            _elapsedTime = 0;
        }
    }
}
