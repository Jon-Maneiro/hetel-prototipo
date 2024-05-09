using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGameController : MonoBehaviour
{

    [SerializeField] private GameObject tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        if (tutorial.Equals(null))
        {
            tutorial = GameObject.Find("TutorialCanvas");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SalirTutorial()
    {
        tutorial.SetActive(false);
    }
}
