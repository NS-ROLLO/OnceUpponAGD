using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headbob : MonoBehaviour
{
    
    [SerializeField] private bool _enable = true;
    [SerializeField, Range(0,0.1f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0,30)] private float _frequency = 10f;
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _camHolder = null;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    [SerializeField] private CharacterController _controller;
    private void Awake()
    {
        _controller =GetComponent<CharacterController>();
        _startPos = _camera.localPosition;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(_controller.velocity.x, 0 , _controller.velocity.z).magnitude;

        if (speed < _toggleSpeed) return;
        if (!_controller.isGrounded) return;
        
        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;

        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos,1 * Time.deltaTime);
    }

    private void Update()
    {
        if (!_enable) return;
       // Debug.Log("onup");
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _camHolder.localPosition.y, transform.position.z);
        pos += _camHolder.forward * 10f;
        return pos;
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }
}
