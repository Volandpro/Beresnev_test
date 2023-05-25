using GlobalServices;
using UnityEngine;
using VContainer;

namespace MainMenu
{
    public class MainMenuUIController : MonoBehaviour
    {
        #region Private variables

        [SerializeField] private GameObject skinsPanel;

        [Inject] private SceneLoaderService m_LoaderService;

        #endregion

        #region Public methods

        public void OnPlay()
        {
            m_LoaderService.Load(2);
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public void OnSkins()
        {
            skinsPanel.SetActive(true);
        }

        #endregion
    }
}