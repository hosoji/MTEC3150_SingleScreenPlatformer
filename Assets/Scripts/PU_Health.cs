using UnityEngine;

public class PU_Health : PowerUp
{
    public override void ApplyEffect()
    {
        player.movementSpeed += 50;

        base.ApplyEffect();

    }

    protected override void NegateEffect()
    {
        base.NegateEffect();
        player.movementSpeed -= 50;
    }

}
