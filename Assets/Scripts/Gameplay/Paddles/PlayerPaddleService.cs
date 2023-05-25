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

        public bool Enabled { get; set; }

        #endregion

        #region Public methods

        public Vector3 GetVelocityFor(Transform _TR)
        {
            if (!Enabled)
            {
                return _TR.position;
            }
            else
            {
                Vector3 worldMousePosition = m_Camera != null
                    ? m_Camera.ScreenToWorldPoint(
                            new Vector3(
                                    Input.mousePosition.x,
                                    Input.mousePosition.y,
                                    _TR.position.z - m_Camera.transform.position.z
                                )
                        )
                    : _TR.position;

                Vector3 position       = _TR.position;
                Vector3 targetPosition = new Vector3(worldMousePosition.x, position.y, position.z);

                float deltaX = targetPosition.x - position.x;

                return Mathf.Abs(deltaX) > 0 ? Vector3.right * deltaX / Time.fixedDeltaTime : Vector3.zero;
            }
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