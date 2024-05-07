using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    private float _tiempoExplosion;
    private float _duracion = 1;

    private float _valorInicial = 0.25f;
    private float _valorFinal = 2f;
    private float _valor;
    [SerializeField] private float cantidadAumento = 0.35f;
    
    // Start is called before the first frame update
    void Start()
    {
        _valor = _valorInicial;
        InvokeRepeating(nameof(Explode),0f,0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
       
    }

    private void Explode()
    {
        if (_valor < _valorFinal)
        {
            _valor += cantidadAumento;
        }
        else
        {
            _valor = _valorFinal;
            Delete();
        }

        gameObject.transform.localScale = new Vector3(_valor, _valor, _valor);
    }

    private void Delete()
    {
        CancelInvoke(nameof(Explode));
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
