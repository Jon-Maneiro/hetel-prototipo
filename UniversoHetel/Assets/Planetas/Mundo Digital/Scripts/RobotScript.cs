using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Planetas.Mundo_Digital.Scripts
{
    public class RobotScript : MonoBehaviour
    {
        private List<Vector3> puntos;
        private NavMeshAgent agent;
        
        void Start()
        {
            PuntoScript.OtroPunto += IrAOtroPunto;
            PuntoScript.DecirPuntos += AniadirPunto;
            
            puntos = new List<Vector3>();
            agent = GetComponent<NavMeshAgent>();

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
            if (robot.Equals(gameObject))
            {
                agent.SetDestination(puntos[Random.Range(0, puntos.Count)]);
            }
        }
    }
}
