using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    private InputActions _control;
    private Rigidbody _rigidbody;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float angle_x;
    [SerializeField] private float angle_y;
    [SerializeField] private float rotationSpeed;

    
    
    private Vector2 move;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    // Start is called before the first frame update

    void Awake()
    {
        _control = new InputActions();
        OnEnable();
        _control.ShipMovement.ForwardMovement.performed += context => InvokeRepeating(nameof(Forward), 0f, 0.01f);
        //control.ShipMovement.ForwardMovement.canceled += context => 
        _control.ShipMovement.HorizontalMovement.performed += ctx => move = (ctx.ReadValue<Vector2>());
        _control.ShipMovement.HorizontalMovement.performed += context => InvokeRepeating(nameof(Turn), 0f, 0.01f); 
        _control.ShipMovement.HorizontalMovement.canceled += ctx => move = Vector2.zero;
        _control.ShipMovement.HorizontalMovement.canceled += context => CancelInvoke(nameof(Turn));
    }

    private void OnEnable()
    {
        _control.ShipMovement.Enable();
    }

    private void OnDisable()
    {
        _control.ShipMovement.Disable();
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void Forward()
    {
        float inputForward = _control.ShipMovement.ForwardMovement.ReadValue<float>();
        _rigidbody.velocity += transform.forward * forwardSpeed * inputForward * Time.deltaTime;
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, move.x * rotationSpeed * Time.fixedDeltaTime);
        TurnShipVisual();
    }

    private void TurnShipVisual()
    {
        transform.localEulerAngles = new Vector3(move.y * angle_y, transform.localEulerAngles.y, -move.x * angle_x);
    }
}
