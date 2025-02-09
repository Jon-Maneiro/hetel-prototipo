using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TubeGameControllerScript : MonoBehaviour
{

    [SerializeField] private GameObject tubeContainer;
    [SerializeField] private GameObject[] tubes;

    [SerializeField] private int totalTubes;
    
    private int _correctTubes = 0;
    [SerializeField]  private int neededCorrectTubes = 0;
    
    [SerializeField] private GameObject canvasWin;

    public static Action Win;
    
    // Start is called before the first frame update
    void Start()
    {
        CamionScript.ActivarVictoria += CanvasWin;
        
        tubeContainer = GameObject.Find("TubeContainer");
        totalTubes = tubeContainer.transform.childCount;

        tubes = new GameObject[totalTubes];

        for (int i = 0; i < tubes.Length; i++)
        {
            tubes[i] = tubeContainer.transform.GetChild(i).gameObject;
        }
    }

    private void CanvasWin()
    {
        canvasWin.SetActive(true);
        StartCoroutine(nameof(EndGame));
    }

    public void CorrectMove()
    {
        _correctTubes += 1;
        if (_correctTubes == neededCorrectTubes)
        {
            Win?.Invoke();
        }
    }

    public void WrongMove()
    {
        _correctTubes -= 1;
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        LoadingData.SceneToLoad = LoadingData.NextContinent;
        SceneManager.LoadScene("LoadingScreen");
    }
}
