using System;
using Gameplay.Paddles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Chip
{
    public class ChipMoveService : IGameloopInitable
    {
        #region Constants

        private const float DISPERSION = 0.2f;

        private const float SPEED = 10f;

        #endregion

        #region Public methods

        public Vector3 CalculateVelocityFor(Vector3 _Direction, Collision _Collision, out float _Modifier)
        {
            _Modifier = 1f;

            Vector3 direction = _Direction;

            if (_Collision.gameObject.TryGetComponent(out BasePaddle paddle))
            {
                _Modifier =  Mathf.Clamp(paddle.Magnitude, 1, 5);
                direction += paddle.Velocity;
            }

            direction.Normalize();

            ContactPoint contact = _Collision.GetContact(0);

            Vector3 normal = new Vector3(
                    contact.normal.x + Random.Range(-DISPERSION, DISPERSION),
                    contact.normal.y + Mathf.Sign(_Direction.y) * Random.Range(0, DISPERSION),
                    contact.normal.z
                ).normalized;

            return Vector3.Reflect(direction, normal) * SPEED;
        }

        public Vector3 GetInitialVelocity()
        {
            return (Vector3.up * Random.Range(-1f, 1f) + Vector3.right * Random.Range(-0.2f, 0.2f)).normalized * SPEED;
        }

        #endregion

        #region IInitable

        public Action OnInit { get; set; }

        void IGameloopInitable.Init()
        {
            OnInit?.Invoke();
        }

        #endregion
    }
}