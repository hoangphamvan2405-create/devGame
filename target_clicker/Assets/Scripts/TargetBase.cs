using UnityEngine;
using DG.Tweening;

public abstract class TargetBase : MonoBehaviour, IClickable
{
    [SerializeField] protected float realtime = 2f;
    [SerializeField] protected int scoreValue = 10;
    [SerializeField] protected float fadeInDuration = 0.5f;
    private float timer;
    private bool isDestroying;

    public static int ScoreValue { get; internal set; }

    protected virtual void Start()
    {
        timer = realtime;
        if (TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            float targetAlpha = spriteRenderer.color.a;
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                0f
            );

            spriteRenderer.DOFade(targetAlpha, fadeInDuration)
                .SetLink(gameObject);
        }
    }

    protected virtual void Update()
    {
        if (isDestroying) return;

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
        if (isDestroying) return;
        isDestroying = true;

        if (!TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            Destroy(gameObject);
            return;
        }

        spriteRenderer.DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
    }
}
