using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace Raul
{
    public class CambiarPlaneta : MonoBehaviour
    {
        [SerializeField] private LocalizedString localStringPlaneta;
        [SerializeField] private TextMeshProUGUI textComp;

        private string _nombrePlaneta;
        private string _pregunta;

        private void Start()
        {
            PlanetScript.ChangeText += ChangeText;
            localStringPlaneta.Arguments = new object[] { _nombrePlaneta, _pregunta };
            localStringPlaneta.StringChanged += UpdateText;
        }

        private void OnDisable()
        {
            localStringPlaneta.StringChanged -= UpdateText;
        }

        private void UpdateText(String value)
        {
            textComp.text = value;
        }

        private void ChangeText(String newText)
        {
            _nombrePlaneta = newText;
            localStringPlaneta.Arguments[0] = _nombrePlaneta;
            localStringPlaneta.RefreshString();
        }
    }
}