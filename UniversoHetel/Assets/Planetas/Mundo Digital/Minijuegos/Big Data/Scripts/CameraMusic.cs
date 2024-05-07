using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class CameraMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip bgm;
        [SerializeField] private AudioClip win;
        [SerializeField] private AudioClip lose;
        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Win()
        {
            _audioSource.clip = win;
            _audioSource.Play();
        }

        public void Lose()
        {
            _audioSource.clip = lose;
            _audioSource.Play();
        }

        public void Bgm()
        {
            _audioSource.clip = bgm;
            _audioSource.Play();
        }
    }
}
