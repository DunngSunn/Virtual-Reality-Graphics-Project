using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character controller")]
    [SerializeField] private CharacterController controller;
    
    [Header("Ground check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Character variables")]
    [SerializeField, Range(5f, 20f)] private float characterSpeed;
    [SerializeField, Range(1f, 5f)] private float jumpHeight;
    [SerializeField] private float gravity;
    
    //Private variables
    private Vector3 _moveWorkSpace;
    private Vector3 _yVelocity;
    private float _xInput;
    private float _zInput;
    private bool _isGrounded;
    private bool _increaseSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _increaseSpeed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _increaseSpeed = false;
        }
        
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");

        _xInput = _increaseSpeed ? _xInput * 2f : _xInput;
        _zInput = _increaseSpeed ? _zInput * 2f : _zInput;

        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, whatIsGround);
        if (_isGrounded && _yVelocity.y < 0f)
        {
            _yVelocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            //v = sqrt(2 * h * g)
            _yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //y = 1/2 * g * t^2
        _yVelocity.y += 1.5f * gravity * Time.deltaTime;
        controller.Move(_yVelocity * Time.deltaTime);
        
        _moveWorkSpace = (transform.right * _xInput + transform.forward * _zInput) * (characterSpeed * Time.deltaTime);
        controller.Move(_moveWorkSpace);
    }
}
