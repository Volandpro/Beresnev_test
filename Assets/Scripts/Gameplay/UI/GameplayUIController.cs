using JetBrains.Annotations;
using UnityEngine;

namespace Gameplay.UI
{
    public class GameplayUIController : MonoBehaviour
    {
        #region Private variables

        [CanBeNull, SerializeField] private GameObject endPanel;

        #endregion

        #region Public methods

        public void ShowEndPanel()
        {
            if (endPanel != null)
            {
                endPanel.SetActive(true);
            }
        }

        #endregion
    }
}