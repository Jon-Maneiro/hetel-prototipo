using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Raul
{
    public class PlanetScript : MonoBehaviour
    {
        public static event Action ActivaCanvas;
        public static event Action<String> ChangeText; 
        [SerializeField] private TextMeshProUGUI planetName;
        
        void Start()
        {
            PointScript.RayHit += RayHit;
        }

        private void RayHit(GameObject hitObject)
        {
            if (!hitObject.Equals(gameObject)) return;
            ActivaCanvas?.Invoke();
            ChangeText?.Invoke(planetName.text);
        }
    }
}

