using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{

    [SerializeField] private GameObject proyectile;
    [SerializeField] private int health;
    [SerializeField] private float timeBetweenShots = 0.25f;
    
    public static event Action<int> DamageReceived;

    private GameControllerAster1.FireMode _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
    private float _shootTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PowerUp.PowerUpTaken += FireModeChanger;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Esto habra que hacerlo con InputManager,de momento queda asi guarrete
        if (Input.GetKey(KeyCode.A) && (transform.position.x > -8) )
        {
            transform.position = new Vector3(transform.position.x - 0.03f,
                transform.position.y,
                transform.position.z); 
        }

        if (Input.GetKey(KeyCode.D) && (transform.position.x < 8))
        {
            transform.position = new Vector3(transform.position.x + 0.03f, 
                transform.position.y,
                transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_shootTimer >= timeBetweenShots)
            {
                FireSelector(_selectedFireMode);    
            }
        }

        if (Input.GetKeyDown((KeyCode.H)))
        {
            _selectedFireMode = GameControllerAster1.FireMode.DoubleFire;
        }
        
        if (Input.GetKeyDown((KeyCode.J)))
        {
            _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
        }
    }

    private void FixedUpdate()
    {
        _shootTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health--;
            DamageReceived?.Invoke(health);
            if (health == 0)
            {
                Destroy(gameObject);
                
            }
        }
    }

    private void FireSelector(GameControllerAster1.FireMode fireMode)
    {
        switch (fireMode)
        {
            case GameControllerAster1.FireMode.SingleFire:
                SingleFireMode();
                break;
            case GameControllerAster1.FireMode.DoubleFire:
                DoubleFireMode();
                break;
            case GameControllerAster1.FireMode.FanFire:
                FanFireMode();
                break;
            case GameControllerAster1.FireMode.Piercing:
                PiercingFireMode();
                break;
        }
    }

    private void FireModeChanger(GameControllerAster1.FireMode fireMode)
    {
        _selectedFireMode = fireMode;
        
        Invoke(nameof(FireModeReset) , 10f);
    }

    private void FireModeReset()
    {
        _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
    }

    //One Shot each time
    private void SingleFireMode()
    {
        Instantiate(proyectile,
            new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);
    }

    private void DoubleFireMode()
    {
        Instantiate(proyectile,
            new Vector3(transform.position.x - 0.1f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);
        Instantiate(proyectile,
            new Vector3(transform.position.x + 0.1f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);
    }

    private void FanFireMode()
    {
        
    }

    private void PiercingFireMode()
    {
        
    }


}
