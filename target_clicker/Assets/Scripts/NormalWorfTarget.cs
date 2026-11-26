using UnityEngine;

public class NormalWorfTarget : TargetBase
{
    protected override void OnExpired()
    {
        GameManager.Instance.LoseSheep(1);
        base.OnExpired();
    }
    public override void OnHit()
    {
        GameManager.Instance.AddScore(scoreValue);
        DestroyTarget();
    }
}
