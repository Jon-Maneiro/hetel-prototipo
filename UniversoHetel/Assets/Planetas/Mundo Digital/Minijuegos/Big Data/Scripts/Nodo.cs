using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class Node : MonoBehaviour
    {
        public bool isUsable;
        public GameObject potion;

        public Node(bool isUsable, GameObject potion)
        {
            this.isUsable = isUsable;
            this.potion = potion;
        }
    }
}