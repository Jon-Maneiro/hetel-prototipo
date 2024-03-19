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
    private float lookSpeed = 75f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    
    public InputActions _control;
    [SerializeField] private float forwardThrustPower;
    [SerializeField] private float maxForwardThrust = 50f;
    [SerializeField] private float horizontalThrustPower;
    private float forwardGlide, HorizontalGlide = 0f;
    [SerializeField] private float speedMult = 1;
    [SerializeField] private float speedMultAngle = 0.5f;
    [SerializeField] private float speedRollMultAngle = 0.05f;
    [SerializeField] private float throttleIncrement = 0.1f;
    [SerializeField] private float reponsiveness = 10f;
    [SerializeField] private float curSpeed;
    private float mouseInputX;
    private float mouseInputY;
    private float speed;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private float responseModifier
    {
        get
        {
            return (_rigidbody.mass / 10f) * reponsiveness;
        }
    }
    
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
        
        if (_control.ShipMovement.ForwardMovement.ReadValue<float>() != 0) throttle += throttleIncrement;
        else if (_control.ShipMovement.HorizontalMovement.ReadValue<float>() != 0) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
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
        Debug.Log("inputDorward: " + inputForward);
        //transform.forward *= inputForward * forwardThrustPower * speedMult * Time.deltaTime;
        //_rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.forward) * inputForward * maxForwardThrust * throttle * speedMult * Time.deltaTime);
        Debug.Log("Velocidad: " + _rigidbody.velocity.magnitude);
        if (_rigidbody.velocity.magnitude >= maxForwardThrust)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxForwardThrust);
        }
        else
        {
            _rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.forward) * inputForward * maxForwardThrust * throttle * speedMult * Time.deltaTime);
        }
        //_rigidbody.transform.forward += new Vector3(0f, 0f, (inputForward * forwardThrustPower) * Time.deltaTime);
    }

    public void HorizontalMoveStart()
    {
        float inputHorizontal = _control.ShipMovement.HorizontalMovement.ReadValue<float>();
        _rigidbody.AddTorque(_rigidbody.transform.TransformDirection(Vector3.forward) * - inputHorizontal * horizontalThrustPower * responseModifier * Time.deltaTime);
        
        //_rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.right) * inputHorizontal * horizontalThrustPower * speedMult * Time.fixedDeltaTime, ForceMode.Force);
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

