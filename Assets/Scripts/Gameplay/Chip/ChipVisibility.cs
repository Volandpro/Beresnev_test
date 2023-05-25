using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Gameplay.Chip
{
    public class ChipVisibility : MonoBehaviour
    {
        #region Private variables

        [Inject] private GameplayStateMachine m_StateMachine;

        #endregion

        #region Private methods

        private void OnBecameInvisible()
        {
            m_StateMachine.Enter<EndState>();
        }

        #endregion
    }
}