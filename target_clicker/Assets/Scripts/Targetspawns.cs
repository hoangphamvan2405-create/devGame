using UnityEngine;

public class Targetspawns : MonoBehaviour
{
   [SerializeField] private TargetBase[] targets;
   [SerializeField] private float spawnInterval = 2f;
   [SerializeField] private Vector2 areaSize = new Vector2(10f, 10f);

    private float timer;

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnTarget();
            timer = spawnInterval;
        }
    
    }
    private void SpawnTarget()
    {
        TargetBase targetPrefab = targets[Random.Range(0, targets.Length)];
        float x = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
        float y = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);

        Instantiate(targetPrefab, new Vector2(x, y), Quaternion.identity);

    }
}