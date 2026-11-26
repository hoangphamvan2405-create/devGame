using UnityEngine;

public class BossTarget : TargetBase
{   
    [SerializeField] private int extraScoreValue = 20;

    protected override void OnExpired()
    {
        GameManager.Instance.LoseSheep(2);
        base.OnExpired();
    }
    public override void OnHit()
    {

        GameManager.Instance.AddScore(scoreValue + extraScoreValue);
        DestroyTarget();
    }
    
}
