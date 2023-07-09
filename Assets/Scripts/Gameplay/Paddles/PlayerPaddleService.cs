using System;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Paddles
{
    public class PlayerPaddleService : IStartable, IGameloopInitable
    {
        #region Private variables

        private Camera m_Camera;

        #endregion

        #region Public properties

        public bool Enabled { private get; set; }

        #endregion

        #region Public methods

        public Vector3 GetVelocityFor(Transform _Paddle)
        {
            if (!Enabled)
            {
                return Vector3.zero;
            }

            Vector3 worldMousePosition = m_Camera != null
                ? m_Camera.ScreenToWorldPoint(
                        new Vector3(
                                Input.mousePosition.x,
                                Input.mousePosition.y,
                                _Paddle.position.z - m_Camera.transform.position.z
                            )
                    )
                : _Paddle.position;

            Vector3 position       = _Paddle.position;
            Vector3 targetPosition = new(worldMousePosition.x, position.y, position.z);

            float deltaX = targetPosition.x - position.x;

            return Mathf.Abs(deltaX) > 0 ? Vector3.right * deltaX / Time.fixedDeltaTime : Vector3.zero;
        }

        #endregion

        #region IInitable

        public Action OnInit { get; set; }

        void IGameloopInitable.Init()
        {
            OnInit?.Invoke();
        }

        #endregion

        #region IStartable

        void IStartable.Start()
        {
            m_Camera = Camera.main;
        }

        #endregion
    }
}