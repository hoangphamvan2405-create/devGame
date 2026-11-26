using UnityEngine;

public class SheepTarget : TargetBase
{
    protected override void OnExpired()
    {
        GameManager.Instance.LoseSheep(1);
        base.OnExpired();
    }

    public override void OnHit()
    {
        GameManager.Instance.AddSheep(1);
        GameManager.Instance.AddScore(scoreValue*2);
        DestroyTarget();
    }
}
