using UnityEngine;

public class PU_Bullet : PowerUp
{

    public Color bulletColor;

    public float speedValue;

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        player.ApplyBulletChanges(speedValue, bulletColor);

    }

    protected override void NegateEffect()
    {
        base.NegateEffect();
        player.ResetBullet();
    }

}
