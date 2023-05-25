using Gameplay.Chip;
using GlobalServices;
using UnityEngine;
using VContainer;

namespace Gameplay.Paddles
{
    [RequireComponent(typeof(CollisionHandler))]
    public abstract class BasePaddle : MonoBehaviour
    {
        #region Private variables

        private Vector3   m_InitPosition;
        private Rigidbody m_Rigidbody;

        [Inject] private ScoreService m_ScoreService;

        #endregion

        #region Public properties

        public float Magnitude => m_Rigidbody.velocity.magnitude;

        public Vector3 Velocity => m_Rigidbody.velocity;

        #endregion

        #region Protected methods

        protected abstract Vector3 GetVelocity();

        protected void MoveToInitPosition()
        {
            transform.position = m_InitPosition;
        }

        #endregion

        #region Private methods

        protected virtual void Start()
        {
            m_Rigidbody    = GetComponent<Rigidbody>();
            m_InitPosition = transform.position;
            
            GetComponent<CollisionHandler>().OnEnter += OnCollision;
        }

        private void FixedUpdate()
        {
            m_Rigidbody.velocity = GetVelocity();
        }

        private void OnCollision(Collision _Collision)
        {
            if (_Collision.gameObject.TryGetComponent(out ChipMove _))
            {
                m_ScoreService.CurrentScore++;
            }
        }

        #endregion
    }
}