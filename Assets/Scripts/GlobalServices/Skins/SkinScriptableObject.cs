using System;
using UnityEngine;

namespace GlobalServices.Skins
{
    [Serializable, CreateAssetMenu(fileName = "Skin", menuName = "Skin")]
    public class SkinScriptableObject : ScriptableObject
    {
        [field: SerializeField]
        public Mesh Mesh { get; set; }

        [field: SerializeField]
        public Color Color { get; set; }

        [field: SerializeField]
        public Texture Texture { get; set; }

        [field: SerializeField]
        public Sprite Sprite { get; set; }

        [field: SerializeField]
        public int Id { get; private set; }

        [field: SerializeField]
        public int NeededLevel { get; private set; }
    }
}