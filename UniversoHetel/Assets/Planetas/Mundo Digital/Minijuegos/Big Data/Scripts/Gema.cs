using System.Collections;
using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class Potion : MonoBehaviour
    {
        public PotionType potionType;

        public int xIndex;
        public int yIndex;

        public bool isMatched;
        public bool isMoving;
        
        private Vector2 _currentPos;
        private Vector2 _targetPos;

        public Potion(int x, int y)
        {
            xIndex = x;
            yIndex = y;
        }

        public void SetIndices(int x, int y)
        {
            xIndex = x;
            yIndex = y;
        }
        
        public void MoveToTarget(Vector2 targetPosition)
        {
            StartCoroutine(MoveCoroutine(targetPosition));
        }

        private IEnumerator MoveCoroutine(Vector2 targetPosition)
        {
            isMoving = true;
            var duration = 0.2f;

            Vector2 startPosition = transform.position;
            var elaspedTime = 0f;

            while (elaspedTime < duration)
            {
                float t = elaspedTime / duration;
                transform.position = Vector2.Lerp(startPosition, targetPosition, t);
                elaspedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            isMoving = false;
        }
    }

    public enum PotionType
    {
        Red,
        Blue,
        Purple,
        Green,
        Yellow,
        Cyan
    }
}