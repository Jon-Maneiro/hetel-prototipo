using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ShipMovement : MonoBehaviour
{
    // Mouse variables to rotate
    private float lookSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    
    public InputActions _control;
    [SerializeField] private float forwardThrustPower;
    [SerializeField] private float maxForwardThrust;
    [SerializeField] private float horizontalThrustPower;
    private float forwardGlide, HorizontalGlide = 0f;
    [SerializeField] private float speedMult = 1;
    [SerializeField] private float speedMultAngle = 0.5f;
    [SerializeField] private float speedRollMultAngle = 0.05f;
    private float mouseInputX;
    private float mouseInputY;
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        
        //Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        
        _control = new InputActions();
        _control.Enable();

        PlayerInput.ForwardEvent += ForwardThrust;
        PlayerInput.HorizontalEvent += HorizontalMoveStart;
        PlayerInput.RotationEvent += RotationMove;
        //PlayerInput.HorizontalEvent -= HorizontalMoveStop;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        
        transform.Rotate(-mouseDistance.y * lookSpeed * Time.deltaTime, mouseDistance.x * lookSpeed * Time.deltaTime, 0f, Space.Self);
    }

    private void ForwardThrust()
    {
        float inputForward = _control.ShipMovement.ForwardMovement.ReadValue<float>();
        _rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.forward) * inputForward * forwardThrustPower * speedMult * Time.fixedDeltaTime, ForceMode.Force);
        
        //_rigidbody.transform.forward += new Vector3(0f, 0f, (inputForward * forwardThrustPower) * Time.deltaTime);
    }

    public void HorizontalMoveStart()
    {
        float inputHorizontal = _control.ShipMovement.HorizontalMovement.ReadValue<float>();
        //_rigidbody.AddTorque(_rigidbody.transform.TransformDirection(Vector3.up) * in);
        
        // _rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.right) * inputHorizontal * horizontalThrustPower * speedMult * Time.fixedDeltaTime, ForceMode.Force);
        //_rigidbody.AddTorque(_rigidbody.transform.right * speedMultAngle * inputHorizontal, ForceMode.VelocityChange);
    }   

     public void HorizontalMoveStop()
     {
         float inputHorizontal = _control.ShipMovement.HorizontalMovement.ReadValue<float>();
         
         // _rigidbody.AddRelativeForce(Vector3.right * glide * horizontalThrustPower * Time.deltaTime);
         // glide *= 0.5f;
         //Vector3 actual = transform.position;
         //_rigidbody.angularVelocity = Vector3.zero;
         //_rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
     }

     public void RotationMove()
     {
         
     }
}

