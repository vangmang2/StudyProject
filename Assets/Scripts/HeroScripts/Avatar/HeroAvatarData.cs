using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Sirenix.Serialization;
using UnityEditor;
using System;



//[CreateAssetMenu(fileName = "HeroAvatarData", menuName = "Scriptable Object/HeroAvatar", order = int.MaxValue)]
public class HeroAvatarData : ScriptableObject
{
    public string avatarName;

    [SerializeField, TableColumnWidth(57), TableList(), VerticalGroup(), LabelText("Head")]
    List<HeroAvatarSlot> headSlots = new List<HeroAvatarSlot>();

    [SerializeField, TableColumnWidth(57), TableList(), VerticalGroup(), LabelText("Body")]
    List<HeroAvatarSlot> bodySlots = new List<HeroAvatarSlot>();

    [SerializeField, TableColumnWidth(57), TableList(), VerticalGroup(), LabelText("Leg")]
    List<HeroAvatarSlot> legSlots = new List<HeroAvatarSlot>();

    [SerializeField, TableColumnWidth(57), TableList(), VerticalGroup(), LabelText("Weapon")]
    List<HeroAvatarSlot> weaponSlots = new List<HeroAvatarSlot>();
}
