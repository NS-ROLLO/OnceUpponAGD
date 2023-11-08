using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    
    public CharacterController controller;
    [Header("Speed and Sprint")]
    [SerializeField,Range(3f,25f)]public float speed = 12f;
    [SerializeField, Range(5f, 35f)] public float sprintSpeed = 20f;
    [SerializeField] public bool isSprinting = false;
    [Header("Crouch")]
    [SerializeField, Range(1f, 15f)] public float crouchSpeed = 3f;
    [SerializeField] public bool isCrouching = false;
    [SerializeField, Range(0.2f, 2f)] public float crouchingHeight = 1.25f;
    [SerializeField, Range(0.01f, 1f)] public float timeToCrouch = 0.25f;

    [Header("Gravity and jump height")]
    [SerializeField, Range(5f, 44f)] public float gravity = -9.81f;
    [SerializeField, Range(1f, 10f)] public float jumpHeight = 3f;
    public static float current_speed;
    [Header("Ground check")]
    [SerializeField] public Transform groundCheck;
    [SerializeField] public float groundDistance = 0.4f;
    [SerializeField] public LayerMask groundMask;
    [Header("Cealing check")]
    [SerializeField] public Transform cealingCheckl;
    [SerializeField] public float cealingDistance = 0.4f;
    [SerializeField] public LayerMask cealingMask;
    float standingHeight = 2f;
    float placeholderOldSpeed;
    float placeholderOldSpeed2;
    Vector3 velocity;
    bool isGrounded;
    bool isUnderCealing;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position , groundDistance , groundMask);
        isUnderCealing = Physics.CheckSphere(cealingCheckl.position , cealingDistance , cealingMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            placeholderOldSpeed = speed;
            speed = sprintSpeed;

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            speed = placeholderOldSpeed;

        }


        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isCrouching = true;
            placeholderOldSpeed2 = speed;
            controller.height = crouchingHeight;
            speed = crouchSpeed;

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && !isUnderCealing)
        {
            isCrouching = false;
            speed = placeholderOldSpeed2;
           // controller.height = standingHeight;
           controller.height = Mathf.Lerp(3f, standingHeight, 4);


        } 

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        current_speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude; ;
    }
}
