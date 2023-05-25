using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace Gameplay.Chip
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ChipMove : MonoBehaviour
    {
        #region Private variables

        private float m_CurrentSpeedMod = 1;

        private Vector3 m_InitialPosition;
        private Vector3 m_Velocity;

        private Rigidbody m_Rigidbody;

        [Inject] private ChipMoveService m_MoveService;

        private Vector3 m_TargetVelocity;

        private Sequence m_Sequence;

        #endregion

        #region Private properties

        private Vector3 Velocity
        {
            get => m_Velocity;
            set
            {
                m_Velocity           = value;
                m_Rigidbody.velocity = m_Velocity;
            }
        }

        #endregion

        #region Private methods

        private void Awake()
        {
            m_InitialPosition = transform.position;

            m_Rigidbody = GetComponent<Rigidbody>();

            m_MoveService.OnInit += InitializeMovement;

            GetComponent<CollisionHandler>().OnEnter += OnCollision;
        }

        private void InitializeMovement()
        {
            m_Sequence.Kill();
            m_CurrentSpeedMod = 1;

            transform.position = m_InitialPosition;

            Velocity = m_MoveService.GetInitialVelocity();
        }

        private void FixedUpdate()
        {
            if (Math.Abs(m_CurrentSpeedMod - 1) > 0.01f)
            {
                Velocity = m_TargetVelocity * m_CurrentSpeedMod;
            }
        }

        private void OnCollision(Collision _Collision)
        {
            m_TargetVelocity = m_MoveService.CalculateVelocityFor(Velocity, _Collision, out float modifier);
            Velocity         = m_TargetVelocity;

            if (Math.Abs(modifier - 1) > 0.01f)
            {
                m_Sequence = DOTween.Sequence();
                m_Sequence.Append(DOVirtual.Float(modifier, 1f, 1f, _M => m_CurrentSpeedMod = _M));
            }
        }

        #endregion
    }
}