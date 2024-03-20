using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCubeScript : MonoBehaviour
{

    public static event Action SumarPunto;
    
    // Start is called before the first frame update
    void Start()
    {
        LaserLogic.CubeHit += CheckCube;
    }

    private void CheckCube(GameObject hitObject)
    {
        if (!hitObject.Equals(gameObject)) return;
        SumarPunto?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        LaserLogic.CubeHit -= CheckCube;
    }
}
