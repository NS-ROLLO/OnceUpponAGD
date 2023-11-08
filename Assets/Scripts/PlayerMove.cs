using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    public AudioMixer audioStepsMixer;

    [SerializeField] private MoveSettings _settings = null;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    [SerializeField] private bool _IsCrouching = false;
    [SerializeField] private bool _IsSprinting = false;
    private float _actualSpeed = 0f;

    [SerializeField] public Transform cealingCheckl;
    [SerializeField] public float cealingDistance = 0.4f;
    [SerializeField] public LayerMask cealingMask;
    bool isUnderCealing;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _actualSpeed = _settings.speed;
    }

    private void Update()
    {
        DefaultMovement();

    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void DefaultMovement()
    {
        if (_controller.isGrounded)
        {
            isUnderCealing = Physics.CheckSphere(cealingCheckl.position, cealingDistance, cealingMask);
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * _actualSpeed;
            _moveDirection.z = input.y * _actualSpeed;
            _moveDirection.y = -_settings.antiBump;
            Debug.Log(_actualSpeed + " - speed");
            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                _IsCrouching = false;
                _controller.height = 2.0f;
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_IsCrouching == false)
                {
                    _IsCrouching = true;
                    _IsSprinting = false;
                    Crouch();

                }
                else if (_IsCrouching == true)
                {
                    _IsCrouching = false;
                    Crouch();

                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (_IsSprinting == false && _IsCrouching == false)
                {
                    _IsSprinting = true;
                    Sprint();
                }


            }
            else
            {
                if (_IsSprinting == true)
                {
                    _IsSprinting = false;
                    Sprint();
                }
            }

        }
        else
        {
            _moveDirection.y -= _settings.gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        _moveDirection.y += _settings.jumpForce;
        
    }

    private void Crouch()
    {
        if (_IsCrouching == false && !isUnderCealing)
        {
            _actualSpeed = _settings.speed;
            _controller.height = 2.0f;
            //_controller.height = Mathf.Lerp(1.0f, 2.0f, 1.2f*Time.deltaTime);

        }
        else if (_IsCrouching == true)
        {
            _actualSpeed = _settings.crouchSpeed;
            _controller.height = _settings.crouchingHeight;
        }
    }

    private void Sprint()
    {
        if (_IsSprinting == false)
        {
            //_actualSpeed =Mathf.Lerp(_settings.speed, _settings.sprintSpeed, 2.0f * Time.deltaTime);
            //Debug.Log(_actualSpeed+" - speed");
            _actualSpeed = _settings.speed;
            audioStepsMixer.SetFloat("pitch", 1f);

        }
        else if (_IsSprinting == true && _IsCrouching == false)
        {
            _actualSpeed = _settings.sprintSpeed;
            audioStepsMixer.SetFloat("pitch", 3f);
        }
    }

}
