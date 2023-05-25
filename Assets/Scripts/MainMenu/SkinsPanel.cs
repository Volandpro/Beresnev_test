using System.Collections.Generic;
using GlobalServices.Progress;
using GlobalServices.Skins;
using UnityEngine;
using VContainer;

namespace MainMenu
{
    public class SkinsPanel : MonoBehaviour
    {
        #region Private variables

        [SerializeField] private GameObject skinCellPrefab;
        [SerializeField] private Transform  tableView;

        [Inject] private SkinsService    m_SkinsService;
        [Inject] private ProgressService m_ProgressService;

        private readonly List<SkinCell> m_AllCells = new List<SkinCell>();

        #endregion

        #region Public methods

        public void OnClose()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Private methods

        private void OnEnable()
        {
            if (m_AllCells.Count == 0)
            {
                foreach (SkinScriptableObject skin in m_SkinsService.Skins)
                {
                    SkinCell newCell = Instantiate(skinCellPrefab, tableView).GetComponent<SkinCell>();

                    newCell.SetSkin(skin, SetActiveSkin);

                    newCell.SyncLock(m_ProgressService.CurrentProgressLevel);

                    m_AllCells.Add(newCell);
                }
            }
            else
            {
                foreach (SkinCell skinCell in m_AllCells)
                {
                    skinCell.SyncLock(m_ProgressService.CurrentProgressLevel);
                }
            }
        }

        private void SetActiveSkin(SkinScriptableObject _Skin)
        {
            if (m_ProgressService.CurrentProgressLevel >= _Skin.NeededLevel)
            {
                m_SkinsService.SetActiveSkin(_Skin);

                foreach (SkinCell skinCell in m_AllCells)
                {
                    skinCell.SyncActive();
                }
            }
        }

        #endregion
    }
}