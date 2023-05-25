using Gameplay.Paddles;
using UnityEngine;

namespace Gameplay.StateMachine.States
{
    public class GameloopState : IState
    {
        #region Private variables

        readonly PlayerPaddleService m_PaddleService;

        #endregion

        #region Constructors

        public GameloopState(PlayerPaddleService _PaddleService)
        {
            m_PaddleService = _PaddleService;
        }

        #endregion

        #region IState

        void IState.Enter()
        {
            Time.timeScale = 1;

            m_PaddleService.Enabled = true;
        }

        void IState.Exit()
        {
        }

        #endregion
    }
}