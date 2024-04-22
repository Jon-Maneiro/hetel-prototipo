using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

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
        }

        public void Initialize(int moveAmount, int goalPoints)
        {
            moves = moveAmount;
            goal = goalPoints;
        }

        private void ChangeTexts()
        {
            pointsTxt.text = "Points: " + points.ToString();
            movesTxt.text = "Moves: " + moves.ToString();
            goalTxt.text = "Goal: " + goal.ToString();
        }

        public void ProcessTurn(int pointsToGain, bool subtractMoves)
        {
            points += pointsToGain;
            if (subtractMoves)
                moves--;

            ChangeTexts();
            
            if (points >= goal)
            {
                //you've won the game
                isGameEnded = true;
                //Display a victory screen
                backgroundPanel.SetActive(true);
                victoryPanel.SetActive(true);
                PotionBoard.Instance.potionParent.SetActive(false);
                return;
            }

            if (moves != 0) return;
            //lose the game
            isGameEnded = true;
            backgroundPanel.SetActive(true);
            losePanel.SetActive(true);
            PotionBoard.Instance.potionParent.SetActive(false);
        }

        //attached to a button to change scene when winning
        public void WinGame()
        {
            SceneManager.LoadScene(0);
        }

        //attached to a button to change scene when losing
        public void LoseGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
