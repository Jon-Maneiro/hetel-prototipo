using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProyectileScript : MonoBehaviour
{

    [SerializeField] private float projectileSpeed;

    public static event Action<GameObject> Hit;
    
    private Rigidbody _projectileBody;

    public bool isExplosive = false;
    // Start is called before the first frame update
    void Start()
    {
        _projectileBody = GetComponent<Rigidbody>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (isExplosive)
        {
            //Invoke Explosion    
        }
        
    }

    private void ApplyForce()
    {
        _projectileBody.AddRelativeForce(gameObject.transform.up * projectileSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Hit?.Invoke(other.gameObject);
        }
        
        Destroy(gameObject);
    }
}
