using UnityEngine;

public class Diraction : MonoBehaviour
{
    public Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(randomX, 0, randomZ).normalized;

        return direction;
    }
}