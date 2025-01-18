using UnityEngine;

public class Direction : MonoBehaviour
{
    private float _minValue = -1f;
    private float _maxValue = 1f;

    public Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(_minValue, _maxValue);
        float randomZ = Random.Range(_minValue, _maxValue);
        Vector3 direction = new Vector3(randomX, 0, randomZ).normalized;

        return direction;
    }
}