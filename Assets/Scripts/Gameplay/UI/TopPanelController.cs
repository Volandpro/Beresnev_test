using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using GlobalServices;
using UnityEngine;
using VContainer;

namespace Gameplay.UI
{
    public class TopPanelController : MonoBehaviour
    {
        #region Private variables

        [SerializeField] private TMPro.TMP_Text scoreLabel;
        [SerializeField] private GameObject     pausePanel;

        [Inject] private GameplayStateMachine m_GameplayStateMachine;
        [Inject] private ScoreService         m_ScoreService;

        #endregion

        #region Public methods

        public void OnPause()
        {
            pausePanel.SetActive(true);

            m_GameplayStateMachine.Enter<PauseState>();
        }

        #endregion

        #region Private methods

        private void Start()
        {
            m_ScoreService.OnCurrentScoreChanged += _Score =>
                scoreLabel.text = $"Current Score {_Score.ToString()}/ Max Score {m_ScoreService.MaxScore.ToString()}";
        }

        #endregion
    }
}