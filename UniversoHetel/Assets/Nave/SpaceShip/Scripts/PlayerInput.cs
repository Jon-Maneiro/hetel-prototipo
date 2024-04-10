using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    // Input Actions
    private InputActions _controls;
    public ShipMovement shipMovement;

    public float angularDragDecayFactor; //Higher Value means less angular drag or rotation slowing
    public float angleOffset;
    public float speedFactor;
    private Vector3 worldMousePosition;
    private float angle;

    // Events
    public static event Action ForwardEvent;
    public static event Action HorizontalEvent;
    public static event Action RotationEvent;
    public static event Action FireEvent;
    public static event Action UpDownEvent;

    // Start is called before the first frame update
    void Start()
    {
        _controls = new InputActions();

        _controls.Enable();

        _controls.ShipMovement.ForwardMovement.performed += context => InvokeRepeating(nameof(Movement), 0f, 0.01f);
        _controls.ShipMovement.ForwardMovement.canceled += context => CancelInvoke(nameof(Movement));
        _controls.ShipMovement.HorizontalMovement.performed += context => InvokeRepeating(nameof(HorizontalMovement), 0f, 0.01f);
        _controls.ShipMovement.HorizontalMovement.canceled += context => CancelInvoke(nameof(HorizontalMovement));
        _controls.ShipMovement.Shoot.performed += context => Shoot();
        _controls.ShipMovement.VerticalMovement.performed += context => InvokeRepeating(nameof(UpDown), 0f, 0.01f);
        _controls.ShipMovement.VerticalMovement.canceled += context => CancelInvoke(nameof(UpDown));
        //     _controls.ShipMovement.HorizontalMovement.canceled += context => CancelInvoke(nameof(Movement));
        //     _controls.ShipMovement.PitchYaw.performed += context => InvokeRepeating(nameof(Movement), 0, 0.05f);
        //     _controls.ShipMovement.RotationMovement.canceled += context => CancelInvoke(nameof(Movement));


    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
    }

    private void Movement()
    {
        if (ForwardEvent != null)
        {
            if (_controls.ShipMovement.ForwardMovement.ReadValue<float>() != 0) ForwardEvent?.Invoke();
            //ForwardEvent?.Invoke();
        }

        if (HorizontalEvent != null)
        {
            if (_controls.ShipMovement.HorizontalMovement.ReadValue<float>() != 0) HorizontalEvent?.Invoke();

            //shipMovement.HorizontalMoveStop();

            //if (_controls.ShipMovement.HorizontalMovement.ReadValue<float>() != 0) HorizontalEvent?.Invoke();
        }

        // if (RotationEvent != null)
        // {
        //     if (_controls.ShipMovement.RotateMovement.ReadValue<float>() != 0) RotationEvent?.Invoke();
        // }
    }

    private void HorizontalMovement()
    {
        if (HorizontalEvent != null)
        {
            if (_controls.ShipMovement.HorizontalMovement.ReadValue<float>() != 0) HorizontalEvent?.Invoke();
        }
    }


    private void Shoot()
    { 
        FireEvent?.Invoke();
    }

    private void UpDown()
    {
        UpDownEvent?.Invoke();
    }

    private void GetMouseInput()
    {
        // Vector3 mousePosition = Input.mousePosition;
        //
        // float yaw = (mousePosition.x - (Screen.width * .5f)) / (Screen.width * .5f);
        //
        // if (RotationEvent != null)
        // {
        //     if (yaw != 0) HorizontalEvent?.Invoke();
        // }
    }
    
}

