using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _targetChangeDistance = 0.1f;
    [SerializeField] private Target _target;

    public event Action<NPC> EndWent;

    private Vector3 _currentTarget;

    private void Start()
    {
        _currentTarget = _target.GetRandomDirection(transform.position.y);
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget) < _targetChangeDistance)
        {
            EndWent?.Invoke(this);
        }
    }
}
