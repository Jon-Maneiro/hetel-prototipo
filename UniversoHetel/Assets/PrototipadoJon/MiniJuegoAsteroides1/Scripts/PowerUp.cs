using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{

    public GameControllerAster1.FireMode _powerUpType;
    public bool randomizePowerUp = false;
    
    
    public static event Action<GameControllerAster1.FireMode> PowerUpTaken;
    
    // Start is called before the first frame update
    void Start()
    {
        randomizePowerUpType();
        Invoke(nameof(GiveForce), 0.2f);
    }

    private void GiveForce()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-400,0));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PowerUpTaken?.Invoke(_powerUpType);
            Destroy(gameObject);
        }
    }

    private void randomizePowerUpType()
    {
        int value = (int)Random.Range(0,3);
        _powerUpType = (GameControllerAster1.FireMode)value;
    }

    private void changeColor()
    {
        //TODO - Actually implement function
    }
}
