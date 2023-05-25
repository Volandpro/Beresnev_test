using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Gameplay
{
    public class GameplayStarter : MonoBehaviour
    {
        #region Private variables

        [Inject] private GameplayStateMachine m_StateMachine;

        #endregion

        #region Private methods

        private void Start()
        {
            m_StateMachine.Enter<InitState>();
        }

        #endregion
    }
}