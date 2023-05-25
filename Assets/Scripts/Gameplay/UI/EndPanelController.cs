using Gameplay.StateMachine;
using Gameplay.StateMachine.States;
using GlobalServices;
using GlobalServices.Progress;
using TMPro;
using UnityEngine;
using VContainer;

namespace Gameplay.UI
{
    public class EndPanelController : MonoBehaviour
    {
        #region Private variables

        [SerializeField] private TMP_Text currentProgressLabel;
        [SerializeField] private TMP_Text maxProgressLabel;
        [SerializeField] private TMP_Text progressSliderLabel;

        [SerializeField] private GameObject newSkinLabel;

        [SerializeField] private UnityEngine.UI.Image progressSliderImage;

        [Inject] private SceneLoaderService   m_LoaderService;
        [Inject] private ProgressService      m_ProgressService;
        [Inject] private GameplayStateMachine m_StateMachine;

        #endregion

        #region Public methods

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

        #region Private methods

        private void OnEnable()
        {
            currentProgressLabel.text      = $"Current Level {m_ProgressService.CurrentProgressLevel.ToString()}";
            maxProgressLabel.text          = $"Max Level {m_ProgressService.MaxProgressLevel.ToString()}";
            progressSliderLabel.text       = m_ProgressService.CurrentProgress.ToString();
            progressSliderImage.fillAmount = m_ProgressService.CurrentProgress / 100f;

            newSkinLabel.SetActive(m_ProgressService.HasNewLevel);
        }

        #endregion
    }
}