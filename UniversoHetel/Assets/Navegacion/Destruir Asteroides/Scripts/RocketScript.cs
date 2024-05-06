using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject explosionGameObject;
    
    private Rigidbody _projectileBody;
    
    // Start is called before the first frame update
    void Start()
    {
        _projectileBody = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(-90f, 0, -5f));
        ApplyForce();
    }

    private void OnDestroy()
    {
        
    }

    private void ApplyForce()
    {
        //_projectileBody.AddRelativeForce(gameObject.transform.up * projectileSpeed);
        InvokeRepeating(nameof(MoveUp),0,0.2f);
    }

    private void MoveUp()
    {
        var speed = 100;
        
        transform.position = new Vector3(transform.position.x,
            transform.position.y + speed * Time.deltaTime,
            transform.position.z);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionGameObject,
                gameObject.transform.position,
                Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
