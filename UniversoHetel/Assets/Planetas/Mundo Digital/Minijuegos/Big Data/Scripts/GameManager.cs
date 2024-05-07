using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private GameObject cam;
        
        public GameObject backgroundPanel;
        public GameObject victoryPanel;
        public GameObject losePanel;

        public int goal;
        public int moves;
        public int points;

        public bool isGameEnded;

        public TMP_Text pointsTxt;
        public TMP_Text movesTxt;
        public TMP_Text goalTxt;
        
        private void Awake()
        {
            Instance = this;
            ChangeTexts();
            cam.GetComponent<CameraMusic>().Bgm();
        }

        public void Initialize(int moveAmount, int goalPoints)
        {
            moves = moveAmount;
            goal = goalPoints;
        }

        private void ChangeTexts()
        {
            pointsTxt.text = points.ToString();
            movesTxt.text = moves.ToString();
            goalTxt.text = goal.ToString();
        }

        public void ProcessTurn(int pointsToGain, bool subtractMoves)
        {
            points += pointsToGain;
            if (subtractMoves)
                moves--;

            ChangeTexts();
            
            if (points >= goal)
            {
                EndGame(true);
                return;
            }

            if (moves != 0) return;
            EndGame(false);
        }

        private void EndGame(bool won)
        {
            isGameEnded = true;
            backgroundPanel.SetActive(false);
            PotionBoard.Instance.potionParent.SetActive(false);
            if (won)
            {
                victoryPanel.SetActive(true);
                cam.GetComponent<CameraMusic>().Win();
            }
            else
            {
                losePanel.SetActive(true);
                cam.GetComponent<CameraMusic>().Lose();
            }
        }
        
        public void WinGame()
        {
            SceneManager.LoadScene(0);
        }
        
        public void LoseGame()
        {
            SceneManager.LoadScene(0);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("CCrush");
        }
    }
}
