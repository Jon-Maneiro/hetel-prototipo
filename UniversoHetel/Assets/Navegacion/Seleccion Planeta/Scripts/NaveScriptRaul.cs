using System;
using UnityEngine;

namespace Raul.scripts
{
    public class NaveScriptRaul : MonoBehaviour
    {
        private GameObject _pos;
        private Vector3 _originalPos;

        private void OnEnable()
        {
            _originalPos = transform.position;
            //PlanetScript.MoveNave += MoverNave;
        }

        private void MoverNave(GameObject punto)
        {
            _pos = punto;
            CancelInvoke(nameof(StopMove));
            InvokeRepeating(nameof(Move), 0f, 0.01f);
        }

        private void MoverNaveFuera()
        {
            CancelInvoke(nameof(Move));
            InvokeRepeating(nameof(StopMove), 0f, 0.01f);
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos.transform.position, 2 * Time.deltaTime);
        }

        private void StopMove()
        {
            transform.position = Vector3.MoveTowards(transform.position, _originalPos, 2 * Time.deltaTime);
        }
    }
}
