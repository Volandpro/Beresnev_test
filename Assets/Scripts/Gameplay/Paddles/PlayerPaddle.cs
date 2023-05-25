using UnityEngine;
using VContainer;

namespace Gameplay.Paddles
{
    public class PlayerPaddle : BasePaddle
    {
        #region Private variables

        [Inject] private PlayerPaddleService m_PlayerPaddleService;

        protected override void Start()
        {
            m_PlayerPaddleService.OnInit += MoveToInitPosition;

            base.Start();
        }

        #endregion

        #region Private methods

        protected override Vector3 GetVelocity()
        {
            return m_PlayerPaddleService.GetVelocityFor(transform);
        }

        #endregion
    }
}