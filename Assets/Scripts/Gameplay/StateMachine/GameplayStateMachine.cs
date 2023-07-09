#nullable enable

using System;
using System.Collections.Generic;
using Gameplay.Chip;
using Gameplay.Paddles;
using Gameplay.StateMachine.States;
using Gameplay.UI;
using GlobalServices;
using GlobalServices.Progress;

namespace Gameplay.StateMachine
{
    public class GameplayStateMachine
    {
        #region Private variables

        IState? m_ActiveState = null;

        private readonly Dictionary<Type, IState> m_States;

        #endregion

        #region Constructors

        public GameplayStateMachine(
                EnemyPaddleService   _EnemyPaddleService,
                PlayerPaddleService  _PlayerPaddleService,
                ChipMoveService      _ChipMoveService,
                ScoreService         _ScoreService,
                GameplayUIController _UIController,
                ProgressService      _ProgressService,
                SaveLoadService      _SaveLoadService
            )
        {
            m_States = new Dictionary<Type, IState>
            {
                [typeof(InitState)] = new InitState(
                        this,
                        _EnemyPaddleService,
                        _PlayerPaddleService,
                        _ChipMoveService,
                        _ScoreService
                    ),
                [typeof(GameloopState)] = new GameloopState(_PlayerPaddleService),
                [typeof(PauseState)]    = new PauseState(_PlayerPaddleService),
                [typeof(EndState)] = new EndState(
                        _PlayerPaddleService,
                        _UIController,
                        _ProgressService,
                        _SaveLoadService,
                        _ScoreService
                    ),
            };
        }

        #endregion

        #region Public methods

        public void Enter<TState>()
        {
            m_ActiveState?.Exit();
            if (m_States.TryGetValue(typeof(TState), out m_ActiveState))
            {
                m_ActiveState.Enter();
            }
            else
            {
                throw new ArgumentException($"State {typeof(TState).FullName} not binded");
            }
        }

        #endregion
    }
}