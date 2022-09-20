using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundChecker;
    public LayerMask groundMask;

    private const float GravityPower = -19.62f;
    private const float JumpHeight = 3f;
    private const float GroundDistance = 0.4f;
    
    public float speed = 12f;
    private Vector3 _velocity;
    private bool _isGround;
    public void Start()
    {
    }

    public void Update()
    {
        _isGround = Physics.CheckSphere(groundChecker.position, GroundDistance, groundMask);
        
        if (_isGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        // Debug.Log("x: " + x);
        // Debug.Log("z: " + z);

        var move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * GravityPower);
        }

        _velocity.y += GravityPower * Time.deltaTime;
        // Debug.Log("_velocity.y: " + _velocity.y);

        controller.Move(_velocity * Time.deltaTime);
        
        // Debug.Log("Time.deltaTime: " + Time.deltaTime);
    }
    
    
}
