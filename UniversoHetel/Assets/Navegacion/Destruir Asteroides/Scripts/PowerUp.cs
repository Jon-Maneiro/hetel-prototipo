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
        //randomizePowerUpType();
        gameObject.transform.Rotate(new Vector3(-90,0,0));
        Invoke(nameof(GiveForce), 0.2f);
    }

    private void GiveForce()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-200,0));
        Debug.Log("Aguacate");
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
        int value = (int)Random.Range(1,4);
        _powerUpType = (GameControllerAster1.FireMode)value;
        //changeColor(_powerUpType);
    }

    private void changeColor(GameControllerAster1.FireMode type)
    {
        var mat = gameObject.GetComponent<Renderer>();
        switch (type)
        {
            case GameControllerAster1.FireMode.Rocket:
                mat.material.SetColor("_Color",Color.red);
                break;
            case GameControllerAster1.FireMode.DoubleFire:
                mat.material.SetColor("_Color",Color.yellow);
                break;
            case GameControllerAster1.FireMode.FanFire:
                mat.material.SetColor("_Color",Color.magenta);
                break;
        }
    }
}
