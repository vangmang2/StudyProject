using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;
using System;
using Sirenix.Serialization;

using ObjectFieldAlignment = Sirenix.OdinInspector.ObjectFieldAlignment;
[Serializable]
public class HeroAvatarSlot : INamedObject
{
    [SerializeField, PreviewField(Alignment = ObjectFieldAlignment.Left), AssetSelector(SearchInFolders = new string[] { "Assets/Sprites/Hero" })]
    Sprite sprite;

    public Sprite GetSprite => sprite;

    [ShowInInspector]
    public string name => sprite ? sprite.name : string.Empty;
}
