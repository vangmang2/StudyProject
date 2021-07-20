using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class HeroBase : MonoBehaviour, ITarget, IMovement, IDamageCauser
{
    [BoxGroup("Avatar", centerLabel: true), SerializeField] protected HeroAvatarData heroAvatarData;
    [BoxGroup("Avatar"), SerializeField] SpriteRenderer srHead, srBody, srLegLeft, srLegRight, srWeapon;
    [BoxGroup("Avarar"), SerializeField] Transform trHead, trBody, trLegLeft, trLegRight, trWeapon, trPivot;


    public Transform pivot => trPivot;
    public float hitpoints { get; private set; }
    public float velocity => 0.5f;          // 나중에 스크립터블 오브젝트로 관리할 것
    public float attackableRange => 0.5f;
    public float damage => 10f;

    protected virtual void Init() { }

    public void InitAvatar()
    {
        srHead.SetSprite(heroAvatarData.spriteDefaultHead);
        srBody.SetSprite(heroAvatarData.spriteDefaultBody);
        srLegLeft.SetSprite(heroAvatarData.spriteDefaultLeg);
        srLegRight.SetSprite(heroAvatarData.spriteDefaultLeg);
        srWeapon.SetSprite(heroAvatarData.spriteDefaultWeapon);
    }

    private void Start()
    {
        heroAvatarData.InitAvatarData();
        InitAvatar();
        Init();
    }

    public void UpdateAvatarView(float deg)
    {
        var direction = GetDirectionByDeg(deg);

        UpdateHead();
        UpdateBody();
        UpdateLeg();
        UpdateWeapon();

        void UpdateHead()
        {
            var headSprite = heroAvatarData.GetHeadSpriteByDirection(direction, out Vector3 scale);
            srHead.SetSprite(headSprite);
            trHead.localScale = scale;
        }

        void UpdateBody()
        {
            var bodySprite = heroAvatarData.GetBodySpriteByDirection(direction, out Vector3 scale);
            srBody.SetSprite(bodySprite);
            trBody.localScale = scale;
        }

        void UpdateLeg()
        {
            var legSprite = heroAvatarData.GetLegSpriteByDirection(direction, out Vector3 scale);
            srLegLeft.SetSprite(legSprite);
            trLegLeft.localScale = scale;
            srLegRight.SetSprite(legSprite);
            trLegRight.localScale = scale;
        }

        void UpdateWeapon()
        {
            trWeapon.localPosition = heroAvatarData.GetWeaponPos(direction, out Vector3 scale, out int sortingOrder);
            trWeapon.localScale = scale;
            srWeapon.sortingOrder = sortingOrder;
        }
    }

    public void UpdateAvatarView(float deg, float dist/*향후 이동속도도 추가될 수 있으니까!*/)
    {
        UpdateAvatarView(deg);
    }

    public HeroDirection GetDirectionByDeg(float deg)
    {
        if (deg <= 120f && deg >= 60f)
            return HeroDirection.forward;

        else if (deg <= 60f && deg >= 0f)
            return HeroDirection.forwardRight;

        else if (deg <= 0f && deg >= -60f)
            return HeroDirection.backwardRight;

        else if (deg <= -60f && deg >= -120f)
            return HeroDirection.backward;

        else if (deg <= -120f && deg >= -180f)
            return HeroDirection.backwardLeft;

        else
            return HeroDirection.forwardLeft;
    }

    public void ReduceHitpoints(IDamageCauser causer)
    {
    }
}
