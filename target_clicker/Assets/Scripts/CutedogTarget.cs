using UnityEngine;

public class CutedogTarget : TargetBase
{
    protected override void OnExpired()
    {
        GameManager.Instance.AddScore(scoreValue);
        base.OnExpired();
    }
    public override void OnHit()
    {
        GameManager.Instance.LoseScore(scoreValue);
        DestroyTarget();
    }
}
