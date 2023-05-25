using System;

namespace GlobalServices
{
    public class SaveLoadService
    {
        #region Public properties

        public Action OnSave { get; set; }
        public Action OnLoad { get; set; }

        #endregion

        #region Public methods

        public void Save()
        {
            OnSave?.Invoke();
        }

        public void Load()
        {
            OnLoad?.Invoke();
        }

        #endregion
    }
}