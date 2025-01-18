using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;

    private Vector3 _currentDiraction;

    private void Update()
    {
        transform.Translate(_currentDiraction * _movementSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _currentDiraction = direction;
    }
}