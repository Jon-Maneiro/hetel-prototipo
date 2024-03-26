using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ordinance : MonoBehaviour
{
    public string ordinanceName = "Laser";
    public float muzzleVelocity = 300f;
    public float armorDamage = 100f;
    public float shieldDamage = 50f;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, .05f);
    }
}
