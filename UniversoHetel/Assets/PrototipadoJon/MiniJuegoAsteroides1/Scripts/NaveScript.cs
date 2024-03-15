using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{

    [SerializeField] private GameObject proyectile;
    [SerializeField] private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Esto habra que hacerlo con InputManager,de momento queda asi guarrete
        if (Input.GetKey(KeyCode.A) && (transform.position.x > -7) )
        {
            transform.position = new Vector3(transform.position.x - 0.02f,
                transform.position.y,
                transform.position.z); 
        }

        if (Input.GetKey(KeyCode.D) && (transform.position.x < 7))
        {
            transform.position = new Vector3(transform.position.x + 0.02f, 
                transform.position.y,
                transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proyectil = Instantiate(proyectile,
                new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z),
                Quaternion.identity);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
