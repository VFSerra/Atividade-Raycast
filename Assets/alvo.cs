using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        FindFirstObjectByType<Spawner>().SpawnTarget();

        Destroy(gameObject);
    }
}