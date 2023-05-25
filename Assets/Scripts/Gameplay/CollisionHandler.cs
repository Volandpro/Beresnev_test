using System;
using UnityEngine;

namespace Gameplay
{
    public class CollisionHandler : MonoBehaviour
    {
        #region Public properties

        public Action<Collision> OnEnter { get; set; }

        #endregion

        #region Private methods

        private void OnCollisionEnter(Collision _Collision)
        {
            OnEnter?.Invoke(_Collision);
        }

        #endregion
    }
}