using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameControllerAster2 : MonoBehaviour
{
    public float asteroidSpeed = 400;
    public float initTimeBetweenEnemies = 1.5f;

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int spawnHeight;
    [SerializeField] private int timeToWin;
    [SerializeField] private float timeBetweenReductionFactor;
    [SerializeField] private bool timed;
    
    private float spannedTime = 0f;
    
    [SerializeField] private GameObject[] asteroids;

    [SerializeField] private GameObject tutorialCanvas;
    private GameObject canvasJuego;
    private GameObject hpContainer;
    private Canvas canvasVictoria;
    private Canvas canvasDerrota;

    /*[SerializeField] private string targetSceneVictory;
    [SerializeField] private string targetSceneDefeat;*/
    
    public static event Action<bool> GameStop;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasVictoria = GameObject.Find("VictoryCanvas").GetComponent<Canvas>();
        canvasDerrota = GameObject.Find("DefeatCanvas").GetComponent<Canvas>();
        canvasJuego = GameObject.Find("GameCanvas");
        hpContainer = canvasJuego.transform.Find("Hearts").gameObject;
        
        NaveScript2.DamageReceived += UpdateHealth;
        
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

    private void OnDestroy()
    {
        NaveScript.DamageReceived -= UpdateHealth;
    }

    private IEnumerator SpawnEnemiesSurvive()
    {
        float timeBetweenEnemies = initTimeBetweenEnemies;
        Vector3 speed = new Vector3(0, -asteroidSpeed, 0);
        
        for (var i = 0; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            timeBetweenEnemies = TimeReduction(timeBetweenEnemies,timeBetweenReductionFactor);
            Vector3 spawnPos = new Vector3(0,spawnHeight,0);
            GameObject newestAsteroid = Instantiate(SelectRandomAsteroid(), spawnPos, Quaternion.identity);
            newestAsteroid.GetComponent<Rigidbody>().AddForce(speed);
            numberOfEnemies--;
        }
        Victory();
    }
    
    private IEnumerator SpawnEnemiesTime()
    {
        float timeBetweenEnemies = initTimeBetweenEnemies;
        Vector3 speed = new Vector3(0, -asteroidSpeed, 0);
        
        while (timeToWin > 0)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            timeBetweenEnemies = TimeReduction(timeBetweenEnemies,timeBetweenReductionFactor);
            Vector3 spawnPos = new Vector3(0,spawnHeight,0);
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
        canvasVictoria.enabled = true;
        Time.timeScale = 0;
        canvasJuego.GetComponent<Canvas>().enabled = false;
        GameStop?.Invoke(true);
        Debug.Log("has ganado yay");
        LoadingData.MinigameWon = true;
        StartCoroutine(nameof(ProxyChangeScene));
        Time.timeScale = 0;
    }

    private void Defeat()
    {
        canvasDerrota.enabled = true;
        Time.timeScale = 0;
        canvasJuego.GetComponent<Canvas>().enabled = false;
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
        List<GameObject> lista = HelperMethods.GetChildren(hpContainer);

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

    public void ExitTutorial()
    {
        tutorialCanvas.SetActive(false);
        Time.timeScale = 1;
    }


}
