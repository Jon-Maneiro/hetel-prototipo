using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Planetas.Mundo_Digital.Scripts
{
    public class RobotScript : MonoBehaviour
    {
        private List<Vector3> puntos;
        private NavMeshAgent agent;
        private Vector3 lastPos;
        
        void Start()
        {
            PuntoScript.OtroPunto += IrAOtroPunto;
            PuntoScript.DecirPuntos += AniadirPunto;
            
            puntos = new List<Vector3>();
            agent = GetComponent<NavMeshAgent>();
            lastPos = new Vector3(0, 0, 0);

            StartCoroutine(nameof(EsperarAPunto));
        }

        private IEnumerator EsperarAPunto()
        {
            yield return new WaitUntil(() => puntos.Count > 20);
            IrAOtroPunto(gameObject);
        }

        private void AniadirPunto(Vector3 pos)
        {
            puntos.Add(pos);
        }

        private void IrAOtroPunto(GameObject robot)
        {
            if (!robot.Equals(gameObject)) return;
            do { 
                agent.SetDestination(puntos[Random.Range(0, puntos.Count)]);
            } while (Vector3.Distance(transform.position, agent.destination) < 1);
        }

        private void OnDestroy()
        {
            PuntoScript.OtroPunto -= IrAOtroPunto;
            PuntoScript.DecirPuntos -= AniadirPunto;
        }
    }
}
