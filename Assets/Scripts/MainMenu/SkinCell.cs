using System;
using GlobalServices.Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class SkinCell : MonoBehaviour
    {
        #region Private variables

        [SerializeField] private GameObject lockImage;
        [SerializeField] private TMP_Text   activeStatus;
        [SerializeField] private Image      skinImage;

        private SkinScriptableObject         m_Skin;
        private Action<SkinScriptableObject> m_OnClick;

        #endregion

        #region Public methods

        public void SyncLock(int _CurrentProgressLevel)
        {
            lockImage.SetActive(_CurrentProgressLevel < m_Skin.NeededLevel);
        }

        public void SyncActive()
        {
            activeStatus.text = m_Skin.IsActive ? "Active" : "Inactive";
        }

        public void OnCellClicked()
        {
            m_OnClick?.Invoke(m_Skin);
        }

        public void SetSkin(SkinScriptableObject _Skin, Action<SkinScriptableObject> _OnClick = null)
        {
            m_Skin    = _Skin;
            m_OnClick = _OnClick;

            skinImage.sprite = _Skin.Sprite;

            SyncActive();
        }

        #endregion
    }
}