using UnityEngine;

public abstract class TargetBase : MonoBehaviour , IClickable
{
    [SerializeField] protected float realtime = 2f;
    [SerializeField] protected int scoreValue = 10;
    private float timer;

    public static int ScoreValue { get; internal set; }

    protected virtual void Start()
    {
        timer = realtime;
    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            OnExpired();
        }
    }
    public abstract void OnHit();
    protected virtual void OnExpired()
    {
        DestroyTarget();
    }

    protected void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
