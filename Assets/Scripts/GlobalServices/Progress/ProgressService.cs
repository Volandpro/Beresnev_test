using GlobalServices.Skins;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GlobalServices.Progress
{
    public class ProgressService : IStartable
    {
        #region Constants

        private const string CURRENT_PROGRESS_LEVEL_PATH = "CurrentProgressLevel";
        private const string CURRENT_PROGRESS_PATH       = "CurrentProgress";

        #endregion

        #region Private variables

        [Inject] private SaveLoadService m_SaveLoadService;

        [Inject] private SkinsService m_SkinsService;

        private int m_CurrentProgress;

        #endregion

        #region Public properties

        public bool HasNewLevel { get; set; }

        public int CurrentProgressLevel { get; private set; }

        public int MaxProgressLevel => m_SkinsService.GetMaxSkinLevel();

        public int MaximumProgress => 100;

        public int CurrentProgress
        {
            get => m_CurrentProgress;
            set
            {
                m_CurrentProgress = value;

                int maximumProgress = MaximumProgress;
                if (m_CurrentProgress >= maximumProgress)
                {
                    if (CurrentProgressLevel < MaxProgressLevel)
                    {
                        CurrentProgressLevel++;
                        HasNewLevel       = true;
                        m_CurrentProgress = CurrentProgressLevel == MaxProgressLevel ? maximumProgress : 0;
                    }
                    else
                    {
                        m_CurrentProgress = maximumProgress;
                    }
                }
            }
        }

        #endregion

        #region IStartable

        void IStartable.Start()
        {
            m_SaveLoadService.OnSave += SaveProgress;
            m_SaveLoadService.OnLoad += LoadProgress;
        }

        #endregion

        #region Private methods

        private void LoadProgress()
        {
            CurrentProgressLevel = PlayerPrefs.GetInt(CURRENT_PROGRESS_LEVEL_PATH, 0);
            CurrentProgress      = PlayerPrefs.GetInt(CURRENT_PROGRESS_PATH, 0);
        }

        private void SaveProgress()
        {
            PlayerPrefs.SetInt(CURRENT_PROGRESS_LEVEL_PATH, CurrentProgressLevel);
            PlayerPrefs.SetInt(CURRENT_PROGRESS_PATH, CurrentProgress);
        }

        #endregion
    }
}