using DG.Tweening;
using UnityEngine;

namespace Gameplay.Chip
{
    [RequireComponent(typeof(CollisionHandler))]
    public class ChipGradient : MonoBehaviour
    {
        #region Constants

        private const float GRADIENT_OFFSET      = 0.2f;
        private const float CHANGE_GRADIENT_TIME = 0.5f;

        #endregion

        #region Private variables

        private static readonly int m_HitPosition = Shader.PropertyToID("_HitPosition");
        private static readonly int m_Hardness    = Shader.PropertyToID("_Hardness");

        private Material m_Material;

        #endregion

        #region Private methods

        private void Start()
        {
            GetComponent<CollisionHandler>().OnEnter += OnCollision;

            m_Material = GetComponent<MeshRenderer>().material;
        }

        private void OnCollision(Collision _Collision)
        {
            m_Material.SetVector(m_HitPosition, _Collision.contacts[0].point - transform.position);
            Sequence sequence = DOTween.Sequence();

            sequence.Append(
                         DOVirtual.Float(
                                 1,
                                 GRADIENT_OFFSET,
                                 CHANGE_GRADIENT_TIME,
                                 _M => m_Material.SetFloat(m_Hardness, _M)
                             )
                     )
                    .Append(
                             DOVirtual.Float(
                                     GRADIENT_OFFSET,
                                     1,
                                     CHANGE_GRADIENT_TIME,
                                     _M => m_Material.SetFloat(m_Hardness, _M)
                                 )
                         )
                    .SetEase(Ease.Linear);
        }

        #endregion
    }
}