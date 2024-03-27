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

    private void ApplyForce()
    {
        Vector3 speed = new Vector3(0, projectileSpeed, 0);
        _projectileBody.AddRelativeForce(speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Hit?.Invoke(other.gameObject);
            Destroy(gameObject);
        }
    }
}
