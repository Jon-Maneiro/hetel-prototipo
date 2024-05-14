using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        [SerializeField] private GameObject particulas;
        [SerializeField] private Material explotionMat;
        [SerializeField] private Texture explotionSprite;
        private bool _started;

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
        
        public void MoveToTarget(Vector3 targetPosition)
        {
            try
            {
                StartCoroutine(MoveCoroutine(targetPosition));
            }
            catch (MissingReferenceException e)
            {
                Debug.Log(e.ToString());
                SceneManager.LoadScene(0);
            }
            
        }

        private IEnumerator MoveCoroutine(Vector3 targetPosition)
        {
            isMoving = true;
            var duration = 0.2f;

            Vector3 startPosition = transform.position;
            var elaspedTime = 0f;

            while (elaspedTime < duration)
            {
                float t = elaspedTime / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elaspedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            isMoving = false;
        }

        public void Destruir(bool gameStarted)
        {
            _started = gameStarted;
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (!_started) return;
            GameObject particulass = Instantiate(this.particulas, transform.position, Quaternion.identity);
            explotionMat.mainTexture = explotionSprite;
            particulass.GetComponent<ParticleManager>().SetMaterial(explotionMat);
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