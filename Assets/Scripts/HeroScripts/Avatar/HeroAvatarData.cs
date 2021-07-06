using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Sirenix.Serialization;
using UnityEditor;
using System;

// 영웅의 스프라이트 정보를 가지고 있는 역할.
// 기본적인 방향에 따른 스프라이트를 반환해주는 역할도 해준다.
// 하지만 무기의 경우 기본, 공격등의 애니메이션이 나뉘어지고 포지션 값등의 복합적인 핸들링이 필요하기에 
// 무기만 예외적으로 어떤 역할을 부여받지 않았다.
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

    [SerializeField]
    Vector2 weaponLeftPos, weaponRightPos;
    [SerializeField]
    int weaponForwardOrder, weaponBackwardOrder;
    public Vector2 GetWeaponLeftPos => weaponLeftPos;
    public Vector2 GetWeaponRightPos => weaponRightPos;

    public Sprite spriteDefaultHead => headSlots.Find(slot => slot.isDefault).GetSprite;
    public Sprite spriteDefaultLeg => legSlots.Find(slot => slot.isDefault).GetSprite;
    public Sprite spriteDefaultWeapon => weaponSlots.Find(slot => slot.isDefault).GetSprite;
    public Sprite spriteDefaultBody => bodySlots.Find(slot => slot.isDefault).GetSprite;

    readonly Dictionary<string, HeroAvatarSlot> headSpriteSlotDic = new Dictionary<string, HeroAvatarSlot>();
    readonly Dictionary<string, HeroAvatarSlot> bodySpriteSlotDic = new Dictionary<string, HeroAvatarSlot>();
    readonly Dictionary<string, HeroAvatarSlot> legSpriteSlotDic = new Dictionary<string, HeroAvatarSlot>();
    readonly Dictionary<string, HeroAvatarSlot> weaponSpriteSlotDic = new Dictionary<string, HeroAvatarSlot>();

    public void InitAvatarData()
    {
        headSlots.SetDatasToDictionary(headSpriteSlotDic);
        bodySlots.SetDatasToDictionary(bodySpriteSlotDic);
        legSlots.SetDatasToDictionary(legSpriteSlotDic);
        weaponSlots.SetDatasToDictionary(weaponSpriteSlotDic);
    }

    public Sprite GetHeadSprite(string name)
        => headSpriteSlotDic[name].GetSprite;

    public Sprite GetBodySprite(string name)
        => bodySpriteSlotDic[name].GetSprite;

    public Sprite GetLegSprite(string name)
        => legSpriteSlotDic[name].GetSprite;

    public Sprite GetWeaponSprite(string name)
        => weaponSpriteSlotDic[name].GetSprite;

    public Sprite GetHeadSpriteByDirection(HeroDirection direction, out Vector3 scale)
    {
        switch (direction)
        {
            case HeroDirection.forward:
                scale = new Vector3(1f, 1f, 1f);
                return headSlots[1].GetSprite;

            case HeroDirection.backward:
                scale = new Vector3(1f, 1f, 1f);
                return headSlots[0].GetSprite;

            case HeroDirection.forwardRight:
                scale = new Vector3(1f, 1f, 1f);
                return headSlots[3].GetSprite;

            case HeroDirection.forwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                return headSlots[3].GetSprite;

            case HeroDirection.backwardRight:
                scale = new Vector3(1f, 1f, 1f);
                return headSlots[2].GetSprite;

            case HeroDirection.backwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                return headSlots[2].GetSprite;

            default:
                scale = new Vector3(1f, 1f, 1f);
                return spriteDefaultHead;
        }
    }

    public Sprite GetBodySpriteByDirection(HeroDirection direction, out Vector3 scale)
    {
        switch (direction)
        {
            case HeroDirection.forward:
            case HeroDirection.forwardRight:
            case HeroDirection.backwardRight:
                scale = new Vector3(1f, 1f, 1f);
                return bodySlots[1].GetSprite;

            case HeroDirection.backward:
            case HeroDirection.backwardLeft:
            case HeroDirection.forwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                return bodySlots[0].GetSprite;
            default:
                scale = new Vector3(1f, 1f, 1f);
                return spriteDefaultBody;
        }
    }

    public Sprite GetLegSpriteByDirection(HeroDirection direction, out Vector3 scale)
    {
        switch (direction)
        {
            case HeroDirection.forward:
            case HeroDirection.forwardRight:
            case HeroDirection.backwardRight:
                scale = new Vector3(1f, 1f, 1f);
                return legSlots[0].GetSprite;

            case HeroDirection.backward:
            case HeroDirection.backwardLeft:
            case HeroDirection.forwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                return legSlots[0].GetSprite;
            default:
                scale = new Vector3(1f, 1f, 1f);
                return spriteDefaultLeg;
        }
    }

    public Vector2 GetWeaponPos(HeroDirection direction, out Vector3 scale, out int sortingOrder)
    {
        switch (direction)
        {
            case HeroDirection.forward:
            case HeroDirection.forwardRight:
                scale = new Vector3(1f, 1f, 1f);
                sortingOrder = 1;
                return weaponRightPos;

            case HeroDirection.backwardRight:
                scale = new Vector3(1f, 1f, 1f);
                sortingOrder = 5;
                return weaponRightPos;

            case HeroDirection.backward:
            case HeroDirection.backwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                sortingOrder = 5;
                return weaponLeftPos;

            case HeroDirection.forwardLeft:
                scale = new Vector3(-1f, 1f, 1f);
                sortingOrder = 1;
                return weaponLeftPos;

            default:
                scale = new Vector3(1f, 1f, 1f);
                sortingOrder = 5;
                return weaponRightPos;
        }
    }

}
