using System;
using Gameplay.Chip;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.Paddles
{
    public class EnemyPaddleService : IStartable, IGameloopInitable
    {
        #region Constants

        private const float ERROR_VALUE = 2;
        private const float ERROR_TIME  = 2;

        #endregion

        #region Private variables

        [Inject] private ChipMove m_Chip;

        private float m_ErrorModifier;

        #endregion

        #region Public properties

        public Action OnInit { get; set; }

        #endregion

        #region Public methods

        public Vector3 GetVelocityFor(Transform _TR)
        {
            m_ErrorModifier = Mathf.Sin(Time.time * ERROR_TIME) * ERROR_VALUE;
            Vector3 position       = _TR.position + Vector3.right * m_ErrorModifier;
            Vector3 targetPosition = new Vector3(m_Chip.transform.position.x, position.y, position.z);

            float deltaX = targetPosition.x - position.x;

            return Vector3.right * (deltaX / Time.fixedDeltaTime);
        }

        #endregion

        #region IInitable

        void IGameloopInitable.Init()
        {
            OnInit?.Invoke();
        }

        #endregion

        #region IStartable

        void IStartable.Start()
        {
        }

        #endregion
    }
}