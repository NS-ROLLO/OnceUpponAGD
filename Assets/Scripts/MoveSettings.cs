using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable_Objects/Movement/Settings")]
public class MoveSettings : ScriptableObject
{
    public float speed { get { return _speed; } private set { _speed = value; } } 
    [SerializeField] private float _speed= 5.5f;

    public float jumpForce { get { return _jumpForce; } private set { _jumpForce = value; } }
    [SerializeField] private float _jumpForce = 15.0f;

    public float antiBump { get { return _antiBump; } private set { _antiBump = value; } }
    [SerializeField] private float _antiBump = 4.5f;

    public float gravity { get { return _gravity; } private set { _gravity = value; } }
    [SerializeField] private float _gravity = 30.0f;

    public float sprintSpeed { get { return _sprintSpeed; } private set { _sprintSpeed = value; } }
    [SerializeField] private float _sprintSpeed = 20.0f;

    public float crouchSpeed { get { return _crouchSpeed; } private set { _crouchSpeed = value; } }
    [SerializeField] private float _crouchSpeed = 2.7f;

    public float crouchingHeight { get { return _crouchingHeight; } private set { _crouchingHeight = value; } }
    [SerializeField] private float _crouchingHeight = 1.0f;
}
