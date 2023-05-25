using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using GlobalServices;
using UnityEngine;
using VContainer;

namespace Gameplay.UI
{
    public class PausePanelController : MonoBehaviour
    {
        #region Private variables

        [Inject] private SceneLoaderService   m_LoaderService;
        [Inject] private GameplayStateMachine m_StateMachine;

        #endregion

        #region Public methods

        public void OnResume()
        {
            m_StateMachine.Enter<GameloopState>();

            gameObject.SetActive(false);
        }

        public void OnRestart()
        {
            m_StateMachine.Enter<InitState>();

            gameObject.SetActive(false);
        }

        public void OnExit()
        {
            m_LoaderService.Load(1);
        }

        #endregion
    }
}