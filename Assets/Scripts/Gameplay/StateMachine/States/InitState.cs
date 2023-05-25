using Gameplay.Paddles;

namespace Gameplay.StateMachine.States
{
    public class InitState : IState
    {
        #region Private variables

        private readonly GameplayStateMachine m_StateMachine;
        private readonly IGameloopInitable            m_EnemyPaddleService;
        private readonly IGameloopInitable            m_PlayerPaddleService;
        private readonly IGameloopInitable            m_ChipMoveService;
        private readonly IGameloopInitable            m_ScoreService;

        #endregion

        #region Constructors

        public InitState(
                GameplayStateMachine _StateMachine,
                IGameloopInitable            _EnemyPaddleService,
                IGameloopInitable            _PlayerPaddleService,
                IGameloopInitable            _ChipMoveService,
                IGameloopInitable            _ScoreService
            )
        {
            m_StateMachine        = _StateMachine;
            m_EnemyPaddleService  = _EnemyPaddleService;
            m_PlayerPaddleService = _PlayerPaddleService;
            m_ChipMoveService     = _ChipMoveService;
            m_ScoreService        = _ScoreService;
        }

        #endregion

        #region IState

        void IState.Enter()
        {
            m_ChipMoveService.Init();
            m_EnemyPaddleService.Init();
            m_PlayerPaddleService.Init();
            m_ScoreService.Init();

            m_StateMachine.Enter<GameloopState>();
        }

        void IState.Exit()
        {
        }

        #endregion
    }
}