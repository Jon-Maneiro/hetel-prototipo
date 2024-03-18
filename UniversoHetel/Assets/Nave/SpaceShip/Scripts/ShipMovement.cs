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
    public InputActions _control;
    [SerializeField] private float forwardThrustPower;
    [SerializeField] private float horizontalThrustPower;
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        
        _control = new InputActions();
        _control.Enable();

        PlayerInput.ForwardEvent += ForwardThrust;
        PlayerInput.HorizontalEvent += HorizontalMoveStart;
        PlayerInput.HorizontalEvent -= HorizontalMoveStop;
    }

    void FixedUpdate()
    {
        
    }

    private void ForwardThrust()
    {
        float inputForward = _control.ShipMovement.ForwardMovement.ReadValue<float>();
        _rigidbody.AddForce(gameObject.transform.forward * inputForward * forwardThrustPower * Time.deltaTime);
        //_rigidbody.transform.forward += new Vector3(0f, 0f, (inputForward * forwardThrustPower) * Time.deltaTime);
    }

    public void HorizontalMoveStart()
    {
        float inputHorizontal = _control.ShipMovement.HorizontalMovement.ReadValue<float>();
        _rigidbody.AddForce(gameObject.transform.right * inputHorizontal * horizontalThrustPower * Time.deltaTime);
        //_rigidbody.AddTorque(gameObject.transform.up * inputHorizontal * horizontalThrustPower * Time.deltaTime);
        transform.Rotate(0f, inputHorizontal * .5f, 0f);
        //_rigidbody.angularVelocity = Vector3.zero;
        
    }

     public void HorizontalMoveStop()
     {
         //Vector3 actual = transform.position;
         //_rigidbody.angularVelocity = Vector3.zero;
         //_rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
     }
}
