using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class HeroBase : MonoBehaviour
{
    [BoxGroup("Avatar", centerLabel: true), SerializeField] HeroAvatarData heroAvatarData;
    [BoxGroup("Avatar"), SerializeField] SpriteRenderer srHead, srBody, srLegLeft, srLegRight, srWeapon;
    [BoxGroup("Avarar"), SerializeField] Transform trHead, trBody, trLegLeft, trLegRight, trWeapon;

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
    }

    // HeroController에서 조이스틱 이벤트에 등록
    public void UpdateAvatarView(float deg, float dist/*향후 이동속도도 추가될 수 있으니까!*/)
    {
        var direction = GetDirectionByDeg(deg);

        UpdateHead();
        UpdateBody();
        UpdateLeg();

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
}
