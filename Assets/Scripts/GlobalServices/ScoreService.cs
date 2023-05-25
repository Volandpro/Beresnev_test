using System;
using Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GlobalServices
{
    public class ScoreService : IStartable, IGameloopInitable, IGameloopEndable
    {
        #region Constants

        private const string SCORE_PATH = "Score";

        #endregion

        #region Private variables

        [Inject] private SaveLoadService m_SaveLoadService;

        private int m_CurrentScore;

        #endregion

        #region Public properties

        public Action<int> OnCurrentScoreChanged { get; set; }

        public int MaxScore { get; private set; }

        public int CurrentScore
        {
            get => m_CurrentScore;
            set
            {
                m_CurrentScore = value;

                OnCurrentScoreChanged?.Invoke(CurrentScore);
            }
        }

        #endregion

        #region IGameloopEndable

        void IGameloopEndable.End()
        {
            if (m_CurrentScore > MaxScore)
            {
                MaxScore = m_CurrentScore;
            }
        }

        #endregion

        #region IGameloopInitable

        public Action OnInit { get; set; }

        void IGameloopInitable.Init()
        {
            CurrentScore = 0;
        }

        #endregion

        #region IStartable

        void IStartable.Start()
        {
            m_SaveLoadService.OnSave += SaveScore;
            m_SaveLoadService.OnLoad += LoadScore;
        }

        #endregion

        #region Private methods

        private void LoadScore()
        {
            MaxScore = PlayerPrefs.GetInt(SCORE_PATH, 0);
        }

        private void SaveScore()
        {
            PlayerPrefs.SetInt(SCORE_PATH, MaxScore);
        }

        #endregion
    }
}