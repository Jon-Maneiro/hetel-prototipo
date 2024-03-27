using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerAster1 : MonoBehaviour
{

    
    public enum FireMode
    {
        SingleFire,
        DoubleFire,
        FanFire,
        Piercing
    }
    
    
    private float _minXSpawnCoords = -6.5f;
    private float _maxXSpawnCoords = 6.5f;
    private float _YSpawnCoord = 7f;

    public float asteroidSpeed = 400;
    public float initTimeBetweenEnemies = 1.5f;

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int timeToWin;
    [SerializeField] private bool timed;

    private float spannedTime = 0f;
    
    [SerializeField] private GameObject[] asteroids;
    // Start is called before the first frame update
    void Start()
    {

        NaveScript.DamageReceived += UpdateHealth;
        
        if (timed)
        {
            StartCoroutine(nameof(SpawnEnemiesTime));
            InvokeRepeating(nameof(SetTimer),0,0.01f);
        }
        else
        { 
            StartCoroutine(nameof(SpawnEnemiesSurvive));
        }

        
    }


    private IEnumerator SpawnEnemiesSurvive()
    {
        float timeBetweenEnemies = initTimeBetweenEnemies;
        float timeBetweenReductionFactor = 0.1f;
        Vector3 speed = new Vector3(0, -asteroidSpeed, 0);
        
        for (var i = 0; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            timeBetweenEnemies = TimeReduction(timeBetweenEnemies,timeBetweenReductionFactor);
            Vector3 spawnPos = new Vector3(
                Random.Range(_minXSpawnCoords,_maxXSpawnCoords),
                _YSpawnCoord,
                0
            );
            GameObject newestAsteroid = Instantiate(SelectRandomAsteroid(), spawnPos, Quaternion.identity);
            newestAsteroid.GetComponent<Rigidbody>().AddForce(speed);
        }
        Victory();
    }
    
    private IEnumerator SpawnEnemiesTime()
    {
        float timeBetweenEnemies = initTimeBetweenEnemies;
        float timeBetweenReductionFactor = 0.1f;
        Vector3 speed = new Vector3(0, -asteroidSpeed, 0);
        
        while (timeToWin > 0)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            timeBetweenEnemies = TimeReduction(timeBetweenEnemies,timeBetweenReductionFactor);
            Vector3 spawnPos = new Vector3(
                Random.Range(_minXSpawnCoords,_maxXSpawnCoords),
                _YSpawnCoord,
                0
            );
            GameObject newestAsteroid = Instantiate(SelectRandomAsteroid(), spawnPos, Quaternion.identity);
            newestAsteroid.GetComponent<Rigidbody>().AddForce(speed);
        }
        Victory();
    }

    private void SetTimer()
    {
        spannedTime += Time.deltaTime;
        //TODO - Add Change to Canvas Timer
    }


    private float TimeReduction(float time,float reductionFactor)
    {
        return time switch
        {
            <= 0.4f => time,
            < 0.5f => time - (reductionFactor / 3),
            < 0.75f => time - (reductionFactor / 2),
            _ => time - reductionFactor
        };
    }

    private GameObject SelectRandomAsteroid()
    {
        int randomNumber = Random.Range(0, asteroids.Length);

        return asteroids[randomNumber];
    }

    private void Victory()
    {
        //TODO - Show Victory Canvas
        Debug.Log("has ganado yay");
        Time.timeScale = 0;
    }

    private void Defeat()
    {
        //TODO - Show Defeat Canvas
        Debug.Log("has perdido yoy");
        Time.timeScale = 0;
    }


    private void UpdateHealth(int health)
    {
        if(health <= 0) Defeat();
        //TODO - Add Canvas Health
    }


}
