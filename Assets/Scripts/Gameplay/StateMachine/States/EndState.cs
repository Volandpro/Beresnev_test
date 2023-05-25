using Gameplay.Paddles;
using Gameplay.UI;
using GlobalServices;
using GlobalServices.Progress;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class EndState : IState
    {
        #region Private variables

        private readonly PlayerPaddleService  m_PaddleService;
        private readonly GameplayUIController m_UIController;
        private readonly ProgressService      m_ProgressService;
        private readonly SaveLoadService      m_SaveLoadService;
        private readonly IGameloopEndable     m_ScoreService;

        #endregion

        #region Constructors

        public EndState(
                PlayerPaddleService  _PaddleService,
                GameplayUIController _UIController,
                ProgressService      _ProgressService,
                SaveLoadService      _SaveLoadService,
                IGameloopEndable     _ScoreService
            )
        {
            m_PaddleService   = _PaddleService;
            m_UIController    = _UIController;
            m_ProgressService = _ProgressService;
            m_SaveLoadService = _SaveLoadService;
            m_ScoreService    = _ScoreService;
        }

        #endregion

        #region IState

        void IState.Enter()
        {
            m_ProgressService.CurrentProgress += 50;

            m_UIController.ShowEndPanel();

            Time.timeScale = 0;

            m_ProgressService.HasNewLevel = false;
            m_PaddleService.Enabled       = false;

            m_ScoreService.End();
            m_SaveLoadService.Save();
        }

        void IState.Exit()
        {
        }

        #endregion
    }
}