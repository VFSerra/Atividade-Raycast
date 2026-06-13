using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float minX = -10f;
    public float maxX = 10f;

    public float minY = 1f;
    public float maxY = 5f;

    public float minZ = 15f;
    public float maxZ = 15f;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 pos = new Vector3(randomX, randomY, randomZ);

        Instantiate(targetPrefab, pos, Quaternion.identity);
    }
}