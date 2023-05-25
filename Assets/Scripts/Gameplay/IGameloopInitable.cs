using System;

namespace Gameplay
{
    public interface IGameloopInitable
    {
        #region Public properties

        Action OnInit { get; set; }

        #endregion

        #region Public methods

        void Init();

        #endregion
    }
}