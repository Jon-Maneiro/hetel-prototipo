using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    private float _tiempoExplosion;
    private float _duracion = 1;

    private float _valorInicial = 0.25f;
    private float _valorFinal = 1.25f;
    private float _valor;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Explode),0f,0.2f);
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
        if (_tiempoExplosion < _duracion)
        {
            _valor = Mathf.Lerp(_valorInicial, _valorFinal, _tiempoExplosion);
            _tiempoExplosion += Time.deltaTime;
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
