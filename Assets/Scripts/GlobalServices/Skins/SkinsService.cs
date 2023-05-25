using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GlobalServices.Skins
{
    public class SkinsService : IStartable
    {
        #region Constants

        private const string CURRENT_SKIN_ID_PATH = "CurrentSkinId";

        #endregion

        #region Private variables

        [Inject] private SaveLoadService m_SaveLoadService;

        #endregion

        #region Public properties

        [CanBeNull]
        public SkinScriptableObject ActiveSkin { get; private set; }

        [CanBeNull]
        public SkinScriptableObject[] Skins { get; private set; }

        #endregion

        #region Public methods

        public void SetActiveSkin(SkinScriptableObject _Skin, bool _Save = true)
        {
            if (ActiveSkin != null)
            {
                ActiveSkin.IsActive = false;
            }

            _Skin.IsActive = true;

            ActiveSkin = _Skin;

            if (_Save)
            {
                m_SaveLoadService.Save();
            }
        }

        public int GetMaxSkinLevel()
        {
            int maxLevel = 0;

            if (Skins != null)
            {
                foreach (SkinScriptableObject skin in Skins)
                {
                    if (skin.NeededLevel > maxLevel)
                    {
                        maxLevel = skin.NeededLevel;
                    }
                }
            }

            return maxLevel;
        }

        #endregion

        #region IStartable

        void IStartable.Start()
        {
            m_SaveLoadService.OnSave += SaveActiveSkin;
            m_SaveLoadService.OnLoad += LoadActiveSkin;
        }

        #endregion

        #region Private methods

        private void LoadActiveSkin()
        {
            Skins = Resources.LoadAll("Skins", typeof(SkinScriptableObject)).Cast<SkinScriptableObject>().ToArray();

            int currentSkinId = PlayerPrefs.GetInt(CURRENT_SKIN_ID_PATH, 0);

            foreach (SkinScriptableObject skin in Skins)
            {
                if (currentSkinId == skin.Id)
                {
                    SetActiveSkin(skin, false);
                }
                else
                {
                    skin.IsActive = false;
                }
            }
        }

        private void SaveActiveSkin()
        {
            if (ActiveSkin != null)
            {
                PlayerPrefs.SetInt(CURRENT_SKIN_ID_PATH, ActiveSkin.Id);
            }
        }

        #endregion
    }
}