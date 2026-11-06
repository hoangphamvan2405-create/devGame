using UnityEngine;

public class ExtraButlletTarget : TargetBase
{
   public override void OnHit()
    {
        GameManager.Instance.ExtraBullet();
        DestroyTarget();
    }
}
