using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> puntos;
    [SerializeField] private List<float> esperas;
    [SerializeField] private List<int> rotaciones;
    [SerializeField] private List<bool> direccion;
    private int _puntoActual;
    private bool _rotated;
    private bool _llegado;
    private Vector3 objetivo;

    public static Action ActivarVictoria;
    private void Start()
    {
        transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.rotation.eulerAngles.y, 270);
        TubeGameControllerScript.Win += StartMoving;
    }
    
    private IEnumerator Rotate()
    {
        _rotated = false;
        CancelInvoke(nameof(TurnAround));
        InvokeRepeating(nameof(TurnAround),0f, 0.005f);
        yield return new WaitUntil(() => _rotated);
        CancelInvoke(nameof(TurnAround));
        _puntoActual++;
        StartCoroutine(IrAPunto(puntos[_puntoActual], esperas[_puntoActual]));
    }
    
    private void TurnAround()
    {
        int newEulerZ;

        if (direccion[_puntoActual])
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 1);
            newEulerZ = (int)transform.eulerAngles.z;
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 1);
            newEulerZ = (int)transform.eulerAngles.z;
        }

        if (newEulerZ == rotaciones[_puntoActual])
        {
            _rotated = true;
        }
    }

    private void StartMoving()
    {
        _puntoActual = 0;
        StartCoroutine(IrAPunto(puntos[_puntoActual], esperas[_puntoActual]));
    }

    private IEnumerator IrAPunto(GameObject punto, float espera)
    {
        yield return new WaitForSeconds(espera);
        objetivo = punto.transform.position;
        _llegado = false;
        InvokeRepeating(nameof(Move), 0f, 0.01f);
        yield return new WaitUntil(() => _llegado);
        CancelInvoke(nameof(Move));

        if (_puntoActual == puntos.Count)
        {
            ActivarVictoria?.Invoke();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo, 0.04f);
        if (Vector3.Distance(transform.position, objetivo) <= 0f)
        {
            _llegado = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PuntoRobotica")) return;
        if (rotaciones[_puntoActual] == (int)transform.eulerAngles.z)
        {
            _puntoActual++;
            StartCoroutine(IrAPunto(puntos[_puntoActual], esperas[_puntoActual]));
        }
        else
        {
            StartCoroutine(nameof(Rotate));
        }
    }
}
