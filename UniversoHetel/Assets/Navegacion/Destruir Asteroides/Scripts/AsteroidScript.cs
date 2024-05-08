using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidScript : MonoBehaviour
{

    [SerializeField] private bool hasSmaller = true;
    [SerializeField] private GameObject smallerMeteorite;
    [SerializeField] private GameObject DoubleShotPower;
    [SerializeField] private GameObject FanShotPower;
    [SerializeField] private GameObject RocketShotPower;
    
    public GameControllerAster1.FireMode _powerUpType;
    
    public float powerUpPercentile = 100f;
    public float speed = 400;

    private bool _hasPowerUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ProyectileScript.Hit += checkHitReceived;
        float tempRand = Random.Range(0f, 100f);
        
        if (tempRand <= powerUpPercentile)
        {
            _hasPowerUp = true;
        }
    }
    private void OnDestroy()
    {
        ProyectileScript.Hit -= checkHitReceived;
    }

    private void checkHitReceived(GameObject go)
    {
        if (go.Equals(gameObject)) hitLogic();
    }

    private void hitLogic()
    {
        if (hasSmaller)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            instantiateSmaller();
            if(_hasPowerUp) instantiatePowerUp();
        }
        
        Destroy(gameObject);
    }

    private void instantiateSmaller()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
        //Vector3 spawnPos1 = new Vector3(x - 1 , y, 0); 
        //Vector3 spawnPos2 = new Vector3(x + 1 , y, 0); 
        Vector3 spawnPos = new Vector3(x , y, 0); 
        
        
        //Vector3 speed1 = new Vector3(-speed, -speed, 0);
        //Vector3 speed2 = new Vector3(speed, -speed, 0);
        Vector3 speed3 = new Vector3(0, -speed, 0);
        
        //GameObject newestAsteroid1 = Instantiate(smallerMeteorite, spawnPos1, Quaternion.identity);
        //GameObject newestAsteroid2 = Instantiate(smallerMeteorite, spawnPos2, Quaternion.identity);
        GameObject newestAsteroid2 = Instantiate(smallerMeteorite, spawnPos, Quaternion.identity);
        
        //newestAsteroid1.GetComponent<Rigidbody>().AddForce(speed1);
        //newestAsteroid2.GetComponent<Rigidbody>().AddForce(speed2);
        newestAsteroid2.GetComponent<Rigidbody>().AddForce(speed3);
    }

    private void instantiatePowerUp()
    {
        randomizePowerUpType();
        float x = transform.position.x;
        float y = transform.position.y;  
        Vector3 spawnPos = new Vector3(x , y, 0);
        switch (_powerUpType)
        {
            case GameControllerAster1.FireMode.FanFire:
                Instantiate(FanShotPower, spawnPos, Quaternion.identity);
                break;
            case GameControllerAster1.FireMode.DoubleFire:
                Instantiate(DoubleShotPower, spawnPos, Quaternion.identity);
                break;
            case GameControllerAster1.FireMode.Rocket:
                Instantiate(RocketShotPower, spawnPos, Quaternion.identity);
                break;
        }
        
    }
    
    private void randomizePowerUpType()
    {
        int value = (int)Random.Range(1,4);
        _powerUpType = (GameControllerAster1.FireMode)value;
        //changeColor(_powerUpType);
    }
}
