using UnityEngine;

public class DirectionGenerator : MonoBehaviour
{
    private float _minValue = -1f;
    private float _maxValue = 1f;

    public Vector3 Create()
    {
        float randomX = Random.Range(_minValue, _maxValue);
        float randomZ = Random.Range(_minValue, _maxValue);

        return new Vector3(randomX, 0, randomZ).normalized;
    }
}