using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
    public class PotionBoard : MonoBehaviour
    {
        public int width = 6;
        public int height = 8;
        public float spacingX;
        public float spacingY;

        private bool _isSelected;
        public bool gameStarted;
        public GameObject[] potionPrefabs;
        private Node[,] _potionBoard;

        public List<GameObject> potionsToDestroy = new();
        public GameObject potionParent;

        [SerializeField] private Potion selectedPotion;

        [SerializeField] private bool isProcessingMove;
        
        [SerializeField]
        List<Potion> potionsToRemove = new();
        public static PotionBoard Instance;
    
        [SerializeField] private LayerMask mask;
        [SerializeField] private Camera cam;
        [SerializeField] private AudioClip @short;
        [SerializeField] private AudioClip @long;
        [SerializeField] private AudioClip @super;

        private void Awake()
        {
            Instance = this;
        }
        
        void Start()
        {
            InitializeBoard();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, Mathf.Infinity, mask)) return;
                if (hit.collider is null || !hit.collider.gameObject.GetComponent<Potion>()) return;
                if (isProcessingMove) return;
                var potion = hit.collider.gameObject.GetComponent<Potion>();
                SelectPotion(potion);
            }

            if (Input.GetMouseButtonUp(0) && _isSelected)
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, Mathf.Infinity, mask)) return;
                if (hit.collider is null || !hit.collider.gameObject.GetComponent<Potion>()) return;
                if (isProcessingMove) return;
                var potion = hit.collider.gameObject.GetComponent<Potion>();
                SelectPotion(potion);
            }
            
            //if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0)) return;
        }

        private void InitializeBoard()
        {
            DestroyPotions();
            _potionBoard = new Node[width, height];

            spacingX = (width - 1f) / 2;
            spacingY = ((height - 1f) / 2f) + 1;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector3 position = new Vector3(x - spacingX, y - spacingY, transform.position.z);
                    int randomIndex = Random.Range(0, potionPrefabs.Length);

                    GameObject potion = Instantiate(potionPrefabs[randomIndex], position, Quaternion.identity);
                    potion.transform.SetParent(potionParent.transform);
                    potion.GetComponent<Potion>().SetIndices(x, y);
                    //_potionBoard[x, y] = new Node(true, potion);
                    _potionBoard[x, y] = potion.AddComponent<Node>();
                    _potionBoard[x, y].potion = potion;
                    _potionBoard[x, y].isUsable = true;
                    potionsToDestroy.Add(potion);
                }
            }

            if (CheckBoard())
            {
                InitializeBoard();
            }
            else
            {
                gameStarted = true;
            }
        }

        private void DestroyPotions()
        {
            if (potionsToDestroy is null) return;
            foreach (GameObject potion in potionsToDestroy)
            {
                potion.GetComponent<Potion>().Destruir(gameStarted);
                //Destroy(potion);
            }
            potionsToDestroy.Clear();
        }

        private bool CheckBoard()
        {
            if (GameManager.Instance.isGameEnded)
                return false;
            
            var hasMatched = false;

            potionsToRemove.Clear();

            foreach(Node nodePotion in _potionBoard)
            {
                if (nodePotion.potion is not null)
                {
                    nodePotion.potion.GetComponent<Potion>().isMatched = false;
                }
            }

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (!_potionBoard[x, y].isUsable) continue;
                    var potion = _potionBoard[x, y].potion.GetComponent<Potion>();

                    if (potion.isMatched) continue;
                    var matchedPotions = IsConnected(potion);

                    if (matchedPotions.ConnectedPotions.Count < 3) continue;
                    var superMatchedPotions = SuperMatch(matchedPotions);

                    potionsToRemove.AddRange(superMatchedPotions.ConnectedPotions);

                    foreach (var pot in superMatchedPotions.ConnectedPotions)
                        pot.isMatched = true;

                    hasMatched = true;
                }
            }
            return hasMatched;
        }
        
        private IEnumerator ProcessTurnOnMatchedBoard(bool substractMoves)
        {
            foreach (Potion potionToRemove in potionsToRemove)
            {
                potionToRemove.isMatched = false;
            }

            switch (potionsToRemove.Count)
            {
                case > 4:
                    AudioSource.PlayClipAtPoint(@super, cam.transform.position);
                    break;
                case 4:
                    AudioSource.PlayClipAtPoint(@long, cam.transform.position);
                    break;
                default:
                    AudioSource.PlayClipAtPoint(@short, cam.transform.position);
                    break;
            }
            
            RemoveAndRefill(potionsToRemove);
            GameManager.Instance.ProcessTurn(potionsToRemove.Count, substractMoves);
            yield return new WaitForSeconds(0.4f);

            if (CheckBoard())
            {
                StartCoroutine(ProcessTurnOnMatchedBoard(false));
            }
        }

        #region Cascading Potions
        private void RemoveAndRefill(List<Potion> potionListToRemove)
        {
            foreach (var potion in potionListToRemove)
            {
                var xIndex = potion.xIndex;
                var yIndex = potion.yIndex;
                
                potion.GetComponent<Potion>().Destruir(gameStarted);
                //Destroy(potion.gameObject);
                
                //_potionBoard[xIndex, yIndex] = new Node(true, null);
                _potionBoard[xIndex, yIndex] = potionParent.AddComponent<Node>();
                _potionBoard[xIndex, yIndex].potion = null;
                _potionBoard[xIndex, yIndex].isUsable = true;
            }

            for (var x=0; x < width; x++)
            {
                for (var y=0; y <height; y++)
                {
                    if (_potionBoard[x, y].potion is not null) continue;
                    RefillPotion(x, y);
                }
            }
        }

        private void RefillPotion(int x, int y)
        {
            var yOffset = 1;
            
            while (y + yOffset < height && _potionBoard[x,y + yOffset].potion == null)
            {
                yOffset++;
            }

            if (y + yOffset < height && _potionBoard[x, y + yOffset].potion != null)
            {
                var potionAbove = _potionBoard[x, y + yOffset].potion.GetComponent<Potion>();
                var targetPos = new Vector3(x - spacingX, y - spacingY, potionAbove.transform.position.z);

                potionAbove.MoveToTarget(targetPos);
                potionAbove.SetIndices(x, y);

                _potionBoard[x, y] = _potionBoard[x, y + yOffset];
                //_potionBoard[x, y + yOffset] = new Node(true, null);
                _potionBoard[x, y + yOffset] = potionParent.AddComponent<Node>();
                _potionBoard[x, y + yOffset].potion = null;
                _potionBoard[x, y + yOffset].isUsable = true;
            }

            if (y + yOffset != height) return;
            SpawnPotionAtTop(x);
        }

        private void SpawnPotionAtTop(int x)
        {
            var index = FindIndexOfLowestNull(x);
            var locationToMoveTo = 8 - index;
            var randomIndex = Random.Range(0, potionPrefabs.Length);
            var newPotion = Instantiate(potionPrefabs[randomIndex], new Vector2(x - spacingX, height - spacingY), Quaternion.identity);
            
            newPotion.transform.SetParent(potionParent.transform);
            newPotion.GetComponent<Potion>().SetIndices(x, index);
            
            //_potionBoard[x, index] = new Node(true, newPotion);
            _potionBoard[x, index] = newPotion.AddComponent<Node>();
            _potionBoard[x, index].potion = newPotion;
            _potionBoard[x, index].isUsable = true;

            var position = newPotion.transform.position;
            var targetPosition = new Vector3(position.x, position.y - locationToMoveTo, position.z);
            
            newPotion.GetComponent<Potion>().MoveToTarget(targetPosition);
        }

        private int FindIndexOfLowestNull(int x)
        {
            var lowestNull = 99;
            for (var y = 7; y >= 0; y--)
            {
                if (_potionBoard[x,y].potion is null)
                {
                    lowestNull = y;
                }
            }
            return lowestNull;
        }
        #endregion

        #region MatchingLogic
        private MatchResult SuperMatch(MatchResult matchedResults)
        {
            switch (matchedResults.Direction)
            {
                case MatchDirection.Horizontal:
                case MatchDirection.LongHorizontal:
                {
                    foreach (var pot in matchedResults.ConnectedPotions)
                    {
                        List<Potion> extraConnectedPotions = new();
                        CheckDirection(pot, new Vector2Int(0, 1), extraConnectedPotions);
                        CheckDirection(pot, new Vector2Int(0, -1), extraConnectedPotions);

                        if (extraConnectedPotions.Count < 2) continue;
                        extraConnectedPotions.AddRange(matchedResults.ConnectedPotions);
                         
                        return new MatchResult
                        {
                            ConnectedPotions = extraConnectedPotions,
                            Direction = MatchDirection.Super
                        };
                    }
                    return new MatchResult
                    {
                        ConnectedPotions = matchedResults.ConnectedPotions,
                        Direction = matchedResults.Direction
                    };
                }
                case MatchDirection.Vertical:
                case MatchDirection.LongVertical:
                {
                    foreach (var pot in matchedResults.ConnectedPotions)
                    {
                        List<Potion> extraConnectedPotions = new();
                        CheckDirection(pot, new Vector2Int(1, 0), extraConnectedPotions);
                        CheckDirection(pot, new Vector2Int(-1, 0), extraConnectedPotions);

                        if (extraConnectedPotions.Count < 2) continue;
                        extraConnectedPotions.AddRange(matchedResults.ConnectedPotions);
                        return new MatchResult
                        {
                            ConnectedPotions = extraConnectedPotions,
                            Direction = MatchDirection.Super
                        };
                    }
                    return new MatchResult
                    {
                        ConnectedPotions = matchedResults.ConnectedPotions,
                        Direction = matchedResults.Direction
                    };
                }
                default:
                    return null;
            }
        }

        private MatchResult IsConnected(Potion potion)
        {
            List<Potion> connectedPotions = new();

            connectedPotions.Add(potion);
            CheckDirection(potion, new Vector2Int(1, 0), connectedPotions);
            CheckDirection(potion, new Vector2Int(-1, 0), connectedPotions);
            switch (connectedPotions.Count)
            {
                case 3:
                    return new MatchResult
                    {
                        ConnectedPotions = connectedPotions,
                        Direction = MatchDirection.Horizontal
                    };
                case > 3:
                    return new MatchResult
                    {
                        ConnectedPotions = connectedPotions,
                        Direction = MatchDirection.LongHorizontal
                    };
            }
            connectedPotions.Clear();
            connectedPotions.Add(potion);
            CheckDirection(potion, new Vector2Int(0, 1), connectedPotions);
            CheckDirection(potion, new Vector2Int(0,-1), connectedPotions);

            return connectedPotions.Count switch
            {
                3 => new MatchResult { ConnectedPotions = connectedPotions, Direction = MatchDirection.Vertical },
                > 3 => new MatchResult { ConnectedPotions = connectedPotions, Direction = MatchDirection.LongVertical },
                _ => new MatchResult { ConnectedPotions = connectedPotions, Direction = MatchDirection.None }
            };
        }

        private void CheckDirection(Potion pot, Vector2Int direction, ICollection<Potion> connectedPotions)
        {
            var potionType = pot.potionType;
            var x = pot.xIndex + direction.x;
            var y = pot.yIndex + direction.y;
            
            while (x >= 0 && x < width && y >= 0 && y < height)
            {
                if (_potionBoard[x,y].isUsable)
                {
                    var neighbourPotion = _potionBoard[x, y].potion.GetComponent<Potion>();
                    if(!neighbourPotion.isMatched && neighbourPotion.potionType == potionType)
                    {
                        connectedPotions.Add(neighbourPotion);

                        x += direction.x;
                        y += direction.y;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        #endregion
    
        #region Swapping Potions
        private void SelectPotion(Potion potion)
        {
            if (selectedPotion is null)
            {
                selectedPotion = potion;
                _isSelected = true;
            }
            else if (selectedPotion == potion)
            {
                selectedPotion = null;
                _isSelected = false;
            }
            else if (selectedPotion != potion)
            {
                SwapPotion(selectedPotion, potion);
                selectedPotion = null;
                _isSelected = false;
            }
        }

        private void SwapPotion(Potion currentPotion, Potion targetPotion)
        {
            if (!IsAdjacent(currentPotion, targetPotion))
                return;

            DoSwap(currentPotion, targetPotion);

            isProcessingMove = true;

            StartCoroutine(ProcessMatches(currentPotion, targetPotion));
        }

        private void DoSwap(Potion currentPotion, Potion targetPotion)
        {
            (_potionBoard[currentPotion.xIndex, currentPotion.yIndex].potion,
                _potionBoard[targetPotion.xIndex, targetPotion.yIndex].potion) = (
                _potionBoard[targetPotion.xIndex, targetPotion.yIndex].potion,
                _potionBoard[currentPotion.xIndex, currentPotion.yIndex].potion);

            var tempXIndex = currentPotion.xIndex;
            var tempYIndex = currentPotion.yIndex;
            currentPotion.xIndex = targetPotion.xIndex;
            currentPotion.yIndex = targetPotion.yIndex;
            targetPotion.xIndex = tempXIndex;
            targetPotion.yIndex = tempYIndex;

            currentPotion.MoveToTarget(_potionBoard[targetPotion.xIndex, targetPotion.yIndex].potion.transform.position);
            targetPotion.MoveToTarget(_potionBoard[currentPotion.xIndex, currentPotion.yIndex].potion.transform.position);
        }

        private IEnumerator ProcessMatches(Potion currentPotion, Potion targetPotion)
        {
            yield return new WaitForSeconds(0.2f);

            if (CheckBoard())
            {
                StartCoroutine(ProcessTurnOnMatchedBoard(true));
            }
            else
            {
                DoSwap(currentPotion, targetPotion);
            }
            isProcessingMove = false;
        }

        private bool IsAdjacent(Potion currentPotion, Potion targetPotion)
        {
            return Math.Abs(currentPotion.xIndex - targetPotion.xIndex) +
                Math.Abs(currentPotion.yIndex - targetPotion.yIndex) == 1;
        }
        #endregion
    }

    public class MatchResult
    {
        public List<Potion> ConnectedPotions;
        public MatchDirection Direction;
    }

    public enum MatchDirection
    {
        Vertical,
        Horizontal,
        LongVertical,
        LongHorizontal,
        Super,
        None
    }
}