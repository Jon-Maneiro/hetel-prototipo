using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerAster1 : MonoBehaviour
{

    private float _minXSpawnCoords = -6.5f;
    private float _maxXSpawnCoords = 6.5f;

    private float _YSpawnCoord = 7f;

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int timeToWin;

    [SerializeField] private GameObject asteroid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        float timeBetweenEnemies = 1.5f;
        Vector3 speed = new Vector3(0, -400, 0);
        
        for (var i = 0; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            timeBetweenEnemies -= 0.01f;
            Vector3 spawnPos = new Vector3(
                Random.Range(_minXSpawnCoords,_maxXSpawnCoords),
                _YSpawnCoord,
                0
            );
            GameObject newestAsteroid = Instantiate(asteroid, spawnPos, Quaternion.identity);
            newestAsteroid.GetComponent<Rigidbody>().AddForce(speed);
        }
    }





}
