using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem ps;
        
        public void SetMaterial(Material mat)
        {
            ParticleSystemRenderer particleSystemRenderer = ps.GetComponent<ParticleSystemRenderer>();
            particleSystemRenderer.material = mat;
        }
    }
}
