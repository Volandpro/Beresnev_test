using GlobalServices.Skins;
using UnityEngine;
using VContainer;

namespace Gameplay.Chip
{
    public class ChipSkin : MonoBehaviour
    {
        #region Private variables

        private MeshFilter   m_MeshFilter;
        private MeshRenderer m_MeshRenderer;

        [Inject] private SkinsService m_SkinsService;

        #endregion

        #region Private methods

        private void Start()
        {
            m_MeshFilter   = GetComponent<MeshFilter>();
            m_MeshRenderer = GetComponent<MeshRenderer>();

            Material material = m_MeshRenderer.material;

            if (m_SkinsService.ActiveSkin != null)
            {
                material.color       = m_SkinsService.ActiveSkin.Color;
                material.mainTexture = m_SkinsService.ActiveSkin.Texture;
                m_MeshFilter.mesh    = m_SkinsService.ActiveSkin.Mesh;
            }
        }

        #endregion
    }
}