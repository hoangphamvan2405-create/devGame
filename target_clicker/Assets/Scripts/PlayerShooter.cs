using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudioSource;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip sheepHitSound;
    [SerializeField] private AudioClip dogHitSound;
    [SerializeField] private AudioClip ammoHitSound;
    [SerializeField] private Sprite targetHitSprite;
    [SerializeField] private Sprite ammoHitSprite;
    [SerializeField] private Sprite missSprite;
    [SerializeField] private float explosionDuration = 0.5f;
    [SerializeField] private float explosionSize = 1f;

    private void PlayHitEffects(Vector2 position, IClickable target)
    {
        AudioClip hitSound = clickSound;
        Sprite hitSprite = targetHitSprite;

        if (target is SheepTarget)
            hitSound = sheepHitSound;
        else if (target is CutedogTarget || target is NormalWorfTarget || target is BossTarget)
            hitSound = dogHitSound;
        else if (target is ExtraButlletTarget)
        {
            hitSound = ammoHitSound;
            hitSprite = ammoHitSprite;
        }

        if (clickAudioSource != null && hitSound != null)
            clickAudioSource.PlayOneShot(hitSound);

        ShowHitSprite(position, hitSprite);
    }

    private void PlayMissEffects(Vector2 position)
    {
        if (clickAudioSource != null && clickSound != null)
            clickAudioSource.PlayOneShot(clickSound);

        ShowHitSprite(position, missSprite);
    }

    private void ShowHitSprite(Vector2 position, Sprite sprite)
    {
        if (sprite == null) return;

        GameObject effect = new GameObject("Click Effect");
        effect.transform.position = position;
        effect.transform.localScale = Vector3.one * explosionSize;

        SpriteRenderer spriteRenderer = effect.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 100;

        Destroy(effect, explosionDuration);
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Camera cam = Camera.main;
        if (cam == null) return;

        Vector2 worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.LoseBullet();
        }

        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);
        if (hitCollider != null && hitCollider.TryGetComponent(out IClickable clickable))
        {
            PlayHitEffects(worldPosition, clickable);
            clickable.OnHit();
        }
        else
        {
            PlayMissEffects(worldPosition);
        }
    }
}