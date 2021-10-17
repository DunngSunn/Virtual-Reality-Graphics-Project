using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;

    [SerializeField, Range(5f, 20f)] private float playerSpeed = 12f;
    [SerializeField, Range(-9.8f, -10f)] private float gravity = -9.8f;
    [SerializeField, Range(1f, 5f)] private float jumpHeight = 3f;
    [SerializeField, Range(.1f, .5f)] private float groundCheckDistance = .3f;
    [SerializeField] private LayerMask whatIsGround;
    
    private Vector3 _workSpace;
    private Vector3 _velocity;
    private float _xInput;
    private float _zInput;
    private bool _isGrounded;

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");

        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, whatIsGround);
        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            //v = sqrt(2 * h * g)
            //Công thức tính vận tốc v để đạt độ cao h từ mặt đất
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        _workSpace = (transform.right * _xInput + transform.forward * _zInput) * (playerSpeed * Time.deltaTime);
        controller.Move(_workSpace);
        
        //v = 1/2 * g * t^2
        //Công thức tính vận tốc v khi vật đang rơi
        //Ở đây test g = -9.8f rơi khá chậm nên tăng lên 1.5 lần
        _velocity.y += 1.5f * gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
    }
}
