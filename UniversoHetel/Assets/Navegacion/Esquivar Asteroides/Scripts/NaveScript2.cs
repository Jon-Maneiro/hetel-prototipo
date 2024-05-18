using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript2 : MonoBehaviour
{
    
    [SerializeField] private int health;
    [SerializeField] private float speed;
    private bool blockMovement = false;
    public static event Action<int> DamageReceived;

    private GameControllerAster1.FireMode _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
    private float _shootTimer = 0;
    
    
    private void Awake()
    {
        Application.targetFrameRate = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameControllerAster1.GameStop += StopMovement;
    }

    private void Update()
    {
        if (!blockMovement)
        {
            //Esto habra que hacerlo con InputManager,de momento queda asi guarrete
            if (Input.GetKey(KeyCode.A) && (transform.position.x > -8))
            {
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    transform.position.z);
            }

            if (Input.GetKey(KeyCode.D) && (transform.position.x < 8))
            {
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    transform.position.z);
            }
            
            if (Input.GetKey(KeyCode.W) && (transform.position.z > -8))
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - speed);
            }

            if (Input.GetKey(KeyCode.S) && (transform.position.z < 8))
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + speed);
            }
            
        }
    }

    private void OnDestroy()
    {
        GameControllerAster1.GameStop -= StopMovement;
    }

    private void FixedUpdate()
    {
        _shootTimer += Time.deltaTime;

    }

    private void StopMovement(bool stop)
    {
        blockMovement = stop;
    }

    private void OnCollisionEnter(Collision other)
    {
        health--;
        DamageReceived?.Invoke(health);
        if (health == 0)
        {
            Destroy(gameObject);
        }
        
        Destroy(other.gameObject);

    }
}
