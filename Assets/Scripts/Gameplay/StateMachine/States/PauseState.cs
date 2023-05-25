using Gameplay.Paddles;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class PauseState : IState
    {
        #region Private variables

        private readonly PlayerPaddleService m_PlayerPaddleService;

        #endregion

        #region Constructors

        public PauseState(PlayerPaddleService _PlayerPaddleService)
        {
            m_PlayerPaddleService = _PlayerPaddleService;
        }

        #endregion

        #region IState

        void IState.Enter()
        {
            Time.timeScale = 0;

            m_PlayerPaddleService.Enabled = false;
        }

        void IState.Exit()
        {
        }

        #endregion
    }
}