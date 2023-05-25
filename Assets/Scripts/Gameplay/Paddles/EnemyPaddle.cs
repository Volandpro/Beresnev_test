using UnityEngine;
using VContainer;

namespace Gameplay.Paddles
{
    public class EnemyPaddle : BasePaddle
    {
        [Inject] private EnemyPaddleService m_EnemyPaddleService;

        protected override void Start()
        {
            m_EnemyPaddleService.OnInit += MoveToInitPosition;

            base.Start();
        }

        protected override Vector3 GetVelocity()
        {
            return m_EnemyPaddleService.GetVelocityFor(transform);
        }
    }
}