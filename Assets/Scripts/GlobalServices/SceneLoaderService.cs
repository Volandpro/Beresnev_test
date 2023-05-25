using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalServices
{
    public class SceneLoaderService
    {
        #region Public methods

        public void Load(int _SceneId, Action _OnLoaded = null)
        {
            LoadScene(_SceneId, _OnLoaded);
        }

        #endregion

        #region Private methods

        private async void LoadScene(int _SceneId, Action _OnLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(_SceneId);

            while (!waitNextScene.isDone)
            {
                await Task.Yield();
            }

            _OnLoaded?.Invoke();
        }

        #endregion
    }
}