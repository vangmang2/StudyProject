using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;
using System;
using Sirenix.Serialization;

using ObjectFieldAlignment = Sirenix.OdinInspector.ObjectFieldAlignment;
[Serializable]
public class HeroAvatarSlot
{
    [SerializeField, PreviewField(Alignment = ObjectFieldAlignment.Left), AssetSelector(SearchInFolders = new string[] { "Assets/Sprites/Hero" })]
    Sprite sprite;

    [ShowInInspector]
    string spriteName => sprite ? sprite.name : string.Empty;
}
