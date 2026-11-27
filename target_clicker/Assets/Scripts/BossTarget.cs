using UnityEngine;

public class BossTarget : TargetBase
{
    [SerializeField] private int extraScoreValue = 20;
    [SerializeField] private int sheepLossOnEscape = 2;

    protected override void OnExpired()
    {
        GameManager.Instance.LoseSheep(sheepLossOnEscape);
        base.OnExpired();
    }
    public override void OnHit()
    {

        GameManager.Instance.AddScore(scoreValue + extraScoreValue);
        DestroyTarget();
    }
    
}
