using GlobalServices;
using UnityEngine;
using VContainer;

namespace Boot
{
    public class BootStarter : MonoBehaviour
    {
        #region Private variables

        [Inject] private SceneLoaderService m_SceneLoaderService;
        [Inject] private SaveLoadService    m_SaveLoadService;

        #endregion

        #region Private methods

        private async void Start()
        {
            m_SaveLoadService.Load();
            await m_SceneLoaderService.Load(1);
        }

        #endregion
    }
}