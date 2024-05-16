using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
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
    [SerializeField] private float speedRollAngle = 0.05f;
    [SerializeField] private float throttleIncrement = 0.1f;
    [SerializeField] private float reponsiveness = 10f;
    [SerializeField] private float curSpeed;
    private float mouseInputX;
    private float mouseInputY;
    private float speed;
    private float deadZoneRadius = .07f;
    private float verticalMove;

    [SerializeField] private float UpDownPower;
    private float responseModifier
    {
        get
        {
            return (_rigidbody.mass / 10f) * reponsiveness;
        }
    }
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Weapon myWeapon;
    
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        myWeapon = transform.GetComponentInChildren<Weapon>();
        
        //Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        
        _control = new InputActions();
        _control.Enable();

       // PlayerInput.ForwardEvent += ForwardThrust;
        PlayerInput.HorizontalEvent += HorizontalMoveStart;
        PlayerInput.RotationEvent += RotationMove;
        PlayerInput.FireEvent += FireWeapon;
        PlayerInput.UpDownEvent += UpDown;
        //PlayerInput.HorizontalEvent -= HorizontalMoveStop;
    }

    private void OnDestroy()
    {
        PlayerInput.HorizontalEvent -= HorizontalMoveStart;
        PlayerInput.RotationEvent -= RotationMove;
        PlayerInput.FireEvent -= FireWeapon;
        PlayerInput.UpDownEvent -= UpDown;
    }

    void Update()
    {
        _rigidbody.freezeRotation = true;
        verticalMove = Input.GetAxis("Vertical");

        // if (_control.ShipMovement.ForwardMovement.ReadValue<float>() >= 0) throttle += throttleIncrement;
        // else if (_control.ShipMovement.ForwardMovement.ReadValue<float>() == 0) throttle = 0;
        // else if (_control.ShipMovement.HorizontalMovement.ReadValue<float>() <= 0) throttle -= throttleIncrement;
        // Debug.Log("Throttle: " + throttle);
        // throttle = Mathf.Clamp(throttle, 0f, 20f);
    }

    private void FireWeapon()
    {
        
        myWeapon.Fire(_rigidbody.velocity);
    }

    private void UpDown()
    {
        float inputUpDown = _control.ShipMovement.VerticalMovement.ReadValue<float>();
        _rigidbody.velocity += transform.up * UpDownPower * inputUpDown * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.forward) * verticalMove * forwardThrustPower * speedMult, ForceMode.VelocityChange);

        
        
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        if (Mathf.Abs(mouseDistance.x) < deadZoneRadius) mouseDistance.x = 0;
        if (Mathf.Abs(mouseDistance.y) < deadZoneRadius) mouseDistance.y = 0;
        //transform.Rotate(-mouseDistance.y * lookSpeed * Time.deltaTime, mouseDistance.x * lookSpeed * Time.deltaTime, 0f, Space.Self);
        transform.Rotate(-mouseDistance.y * lookSpeed * Time.deltaTime, mouseDistance.x * lookSpeed * Time.deltaTime, 0f, Space.Self);
        
    }
    

    private void ForwardThrust()
    {
        float inputForward = _control.ShipMovement.ForwardMovement.ReadValue<float>();
        if (inputForward == 0) _rigidbody.velocity = Vector3.forward * 0 * Time.fixedDeltaTime;
        Debug.Log("inputDorward: " + inputForward);
        //transform.forward *= inputForward * forwardThrustPower * speedMult * Time.deltaTime;
        //_rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.forward) * inputForward * maxForwardThrust * throttle * speedMult * Time.deltaTime);
        Debug.Log("Velocidad: " + _rigidbody.velocity.magnitude);
        if (_rigidbody.velocity.magnitude < maxForwardThrust)
        {
            _rigidbody.velocity += transform.forward * forwardThrustPower * inputForward * Time.fixedDeltaTime;
            //_rigidbody.AddRelativeForce(new Vector3(0f, 0f, 1f) * inputForward * forwardThrustPower * speedMult * Time.fixedDeltaTime);

        }
        else
        {
            //_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, maxForwardThrust);
            _rigidbody.velocity = transform.forward * 100 * Time.fixedDeltaTime;
        }
        //_rigidbody.transform.forward += new Vector3(0f, 0f, (inputForward * forwardThrustPower) * Time.deltaTime);
    }

    public void HorizontalMoveStart()
    {
        float inputHorizontal = _control.ShipMovement.HorizontalMovement.ReadValue<float>();
        //_rigidbody.AddTorque(_rigidbody.transform.TransformDirection(Vector3.up) * - inputHorizontal * horizontalThrustPower * responseModifier * Time.deltaTime);
        //Debug.Log("inputHorizontal: " + inputHorizontal);
        //_rigidbody.AddForce(_rigidbody.transform.TransformDirection(Vector3.right) * inputHorizontal * horizontalThrustPower * speedMult * Time.fixedDeltaTime, ForceMode.Force);
        _rigidbody.AddTorque(transform.forward * speedMultAngle * speedRollAngle * inputHorizontal * Time.fixedDeltaTime, ForceMode.VelocityChange);
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

