using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameControllerAster1 : MonoBehaviour
{

    
    public enum FireMode
    {
        SingleFire,
        DoubleFire,
        FanFire,
        Rocket
    }
    
    
    private float _minXSpawnCoords = -6.5f;
    private float _maxXSpawnCoords = 6.5f;
    private float _ySpawnCoord = 7f;

    public float asteroidSpeed = 400;
    public float initTimeBetweenEnemies = 1.5f;

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int timeToWin;
    [SerializeField] private bool timed;

    private float _spannedTime = 0f;
    
    [SerializeField] private GameObject[] asteroids;
    private GameObject _canvasJuego;
    private GameObject _hpContainer;
    private Canvas _canvasVictoria;
    private Canvas _canvasDerrota;
    private Canvas _canvasTutorial;

    /*[SerializeField] private string targetSceneVictory;
    [SerializeField] private string targetSceneDefeat;*/
    
    public static event Action<bool> GameStop;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasVictoria = GameObject.Find("VictoryCanvas").GetComponent<Canvas>();
        _canvasDerrota = GameObject.Find("DefeatCanvas").GetComponent<Canvas>();
        _canvasJuego = GameObject.Find("GameCanvas");
        _canvasTutorial = GameObject.Find("TutorialCanvas").GetComponent<Canvas>();
        _hpContainer = _canvasJuego.transform.Find("Hearts").gameObject;
        
        NaveScript.DamageReceived += UpdateHealth;
        GameStop?.Invoke(true);
        
        if (timed)
        {
            StartCoroutine(nameof(SpawnEnemiesTime));
            InvokeRepeating(nameof(SetTimer),0,0.01f);
        }
        else
        { 
            StartCoroutine(nameof(SpawnEnemiesSurvive));
        }

        Time.timeScale = 0;
    }

    public void ConfirmTutorial()
    {
        _canvasTutorial.gameObject.SetActive(false);
        GameStop?.Invoke(false);
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        NaveScript.DamageReceived -= UpdateHealth;
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
                _ySpawnCoord,
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
                _ySpawnCoord,
                0
            );
            GameObject newestAsteroid = Instantiate(SelectRandomAsteroid(), spawnPos, Quaternion.identity);
            newestAsteroid.GetComponent<Rigidbody>().AddForce(speed);
        }
        Victory();
    }

    private void SetTimer()
    {
        _spannedTime += Time.deltaTime;
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
        _canvasVictoria.enabled = true;
        _canvasJuego.GetComponent<Canvas>().enabled = false;
        GameStop?.Invoke(true);
        Debug.Log("has ganado yay");
        LoadingData.MinigameWon = true;
        StartCoroutine(nameof(ProxyChangeScene));
        Time.timeScale = 0;
    }

    private void Defeat()
    {
        _canvasDerrota.enabled = true;
        _canvasJuego.GetComponent<Canvas>().enabled = false;
        GameStop?.Invoke(true);
        Debug.Log("has perdido yoy");
        LoadingData.MinigameWon = false;
        StartCoroutine(nameof(ProxyChangeScene));
        Time.timeScale = 0;

    }

    private IEnumerator ProxyChangeScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        if (LoadingData.MinigameWon)
        {
            ChangeScene(LoadingData.NextPlanet);
        }
        else
        {
            ChangeScene(LoadingData.CurrentScene);
        }


    }

    private void ChangeScene(string targetScene)
    {
        Time.timeScale = 1;
        LoadingData.SceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScreen");
    }

    private void UpdateHealth(int health)
    {
        List<GameObject> lista = HelperMethods.GetChildren(_hpContainer);

        switch (health)
        {
            case 3:
                lista[0].gameObject.GetComponent<Image>().enabled = true;
                lista[1].gameObject.GetComponent<Image>().enabled = true;
                lista[2].gameObject.GetComponent<Image>().enabled = true;
                break;
            case 2:
                lista[0].gameObject.GetComponent<Image>().enabled = false;
                lista[1].gameObject.GetComponent<Image>().enabled = true;
                lista[2].gameObject.GetComponent<Image>().enabled = true;
                break;
            case 1:
                lista[0].gameObject.GetComponent<Image>().enabled = false;
                lista[1].gameObject.GetComponent<Image>().enabled = false;
                lista[2].gameObject.GetComponent<Image>().enabled = true;
                break;
            case 0:
                lista[0].gameObject.GetComponent<Image>().enabled = false;
                lista[1].gameObject.GetComponent<Image>().enabled = false;
                lista[2].gameObject.GetComponent<Image>().enabled = false;
                Defeat();
                break;
            default:
                if (health > 3)
                {
                    lista[0].gameObject.GetComponent<Image>().enabled = true;
                    lista[1].gameObject.GetComponent<Image>().enabled = true;
                    lista[2].gameObject.GetComponent<Image>().enabled = true;
                }
                break;
        }
        
    }


}
