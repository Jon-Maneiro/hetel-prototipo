using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{

    [SerializeField] private GameObject proyectile;
    [SerializeField] private int health;
    [SerializeField] private float timeBetweenShots = 0.25f;
    private bool blockMovement = false;
    public static event Action<int> DamageReceived;

    private GameControllerAster1.FireMode _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
    private float _shootTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PowerUp.PowerUpTaken += FireModeChanger;
        GameControllerAster1.GameStop += StopMovement;
    }

    // Update is called once per frame
    void Update()
    {

        if (!blockMovement)
        {
            //Esto habra que hacerlo con InputManager,de momento queda asi guarrete
            if (Input.GetKey(KeyCode.A) && (transform.position.x > -8))
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

            if (Input.GetKey(KeyCode.Space))
            {
                if (_shootTimer >= timeBetweenShots)
                {
                    _shootTimer = 0;
                    FireSelector(_selectedFireMode);
                }
            }

            /*QUITAR ESTO DEBUG DEBUG DEBUG DEBUG DEVELOPMENT*/
            if (Input.GetKeyDown((KeyCode.H)))
            {
                _selectedFireMode = GameControllerAster1.FireMode.DoubleFire;
            }

            if (Input.GetKeyDown((KeyCode.J)))
            {
                _selectedFireMode = GameControllerAster1.FireMode.SingleFire;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                _selectedFireMode = GameControllerAster1.FireMode.FanFire;
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
            //case GameControllerAster1.FireMode.Piercing:
                //PiercingFireMode();
                //break;
        }
    }

    private void FireModeChanger(GameControllerAster1.FireMode fireMode)
    {
        _selectedFireMode = fireMode;
        CancelInvoke(nameof(FireModeReset));
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
        GameObject leftProyectile = Instantiate(proyectile,
            new Vector3(transform.position.x - 0.1f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);
        GameObject rightProyectile = Instantiate(proyectile,
            new Vector3(transform.position.x + 0.1f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);
    }

    private void FanFireMode()
    {
        GameObject centerProyectile  = Instantiate(proyectile,
            new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);

        GameObject leftProyectile = Instantiate(proyectile,
            new Vector3(transform.position.x - 0.25f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);;
        leftProyectile.transform.eulerAngles = new Vector3(0, 0, 25f);

        GameObject rightProyectile = Instantiate(proyectile,
            new Vector3(transform.position.x + 0.25f, transform.position.y + 0.75f, transform.position.z),
            Quaternion.identity);;
        rightProyectile.transform.eulerAngles = new Vector3(0, 0, -25f);
    }
    


}
