using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] collectiblePrefabs; 
    [SerializeField] private int collectibleCount = 30;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;

    private void Start()
    {
        for (int i = 0; i < collectibleCount; i++)
        {
            int type = Random.Range(0, collectiblePrefabs.Length);
            Vector2 pos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(collectiblePrefabs[type], pos, Quaternion.identity);
        }
    }
}
