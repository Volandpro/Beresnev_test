namespace Gameplay.StateMachine.States
{
    public class InitState : IState
    {
        #region Private variables

        private readonly GameplayStateMachine m_StateMachine;
        readonly         IGameloopInitable[]  m_Initables;

        #endregion

        #region Constructors

        public InitState(
                GameplayStateMachine _StateMachine,
                params IGameloopInitable[] _Initables
            )
        {
            m_StateMachine        = _StateMachine;
            m_Initables           = _Initables;
        }

        #endregion

        #region IState

        void IState.Enter()
        {
            foreach (IGameloopInitable initable in m_Initables)
            {
                initable.Init();
            }
            m_StateMachine.Enter<GameloopState>();
        }

        void IState.Exit()
        {
        }

        #endregion
    }
}