using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadCubeScript : MonoBehaviour
{
    public static event Action RestarPunto;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ParticleSystem _explosion1;
    [SerializeField] private ParticleSystem _explosion2;
    [SerializeField] private ParticleSystem _explosion3;
    
    // Start is called before the first frame update
    void Start()
    {
        LaserLogic.CubeHit += CheckCube;
        // _explosion.transform = transform;
    }
    
    private void CheckCube(GameObject hitObject)
    {
        if (!hitObject.Equals(gameObject)) return;
        RestarPunto?.Invoke();

        Instantiate(_explosion, transform.position, transform.rotation);
        Instantiate(_explosion1, transform.position, transform.rotation);
        Instantiate(_explosion2, transform.position, transform.rotation);
        Instantiate(_explosion3, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        LaserLogic.CubeHit -= CheckCube;
    }
}
