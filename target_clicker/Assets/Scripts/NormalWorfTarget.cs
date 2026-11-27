using UnityEngine;

public class NormalWorfTarget : TargetBase
{
    [SerializeField] private int sheepLossOnEscape = 1;

    protected override void OnExpired()
    {
        GameManager.Instance.LoseSheep(sheepLossOnEscape);
        base.OnExpired();
    }
    public override void OnHit()
    {
        GameManager.Instance.AddScore(scoreValue);
        DestroyTarget();
    }
}
