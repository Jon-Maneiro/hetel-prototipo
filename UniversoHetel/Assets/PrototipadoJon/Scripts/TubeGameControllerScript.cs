using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class TubeGameControllerScript : MonoBehaviour
{

    [SerializeField] private GameObject tubeContainer;
    [SerializeField] private GameObject[] tubes;

    [SerializeField] private int totalTubes;
    
    private int _correctTubes = 0;
    [SerializeField]  private int neededCorrectTubes = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        totalTubes = tubeContainer.transform.childCount;

        tubes = new GameObject[totalTubes];

        for (int i = 0; i < tubes.Length; i++)
        {
            tubes[i] = tubeContainer.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        _correctTubes += 1;
        if (_correctTubes == neededCorrectTubes)
        {
            Debug.Log("heeeeeey que bien, has ganado bro, sigue estudiando");
        }
    }

    public void WrongMove()
    {
        _correctTubes -= 1;
    }
}
