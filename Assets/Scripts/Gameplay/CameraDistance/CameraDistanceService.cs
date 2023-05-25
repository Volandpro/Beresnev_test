using UnityEngine;
using VContainer.Unity;

namespace Gameplay.CameraDistance
{
    public class CameraDistanceService : IStartable
    {
        #region IStartable

        void IStartable.Start()
        {
            UnityEngine.Camera camera = UnityEngine.Camera.main;

            if (camera != null)
            {
                camera.transform.position = Vector3.forward * (-Mathf.Clamp(19 * 0.56f / camera.aspect, 19, 22));
            }
        }

        #endregion
    }
}