using UnityEngine;

namespace Internal.Codebase
{
    public class EndGameController : MonoBehaviour
    {
        [SerializeField] private GameObject safeAndTicketGroup;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private SafeBalanceUI safe;

        public bool IsGameEnd { get; private set; }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (!IsGameEnd) return;

            safeAndTicketGroup.SetActive(false);
            endGamePanel.SetActive(true);
        }

        public void EndGame()
        {
            IsGameEnd = true;
            
            safeAndTicketGroup.SetActive(false);
            endGamePanel.SetActive(true);
        }

        public void SetIsGameEnd(bool isGameEnd) => 
            IsGameEnd = isGameEnd;
    }
}

