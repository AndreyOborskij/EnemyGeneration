using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private SpawnerEnemies _spawnerEnemies;
    [SerializeField] private List<Transform> _startPositions;

    private float _repeatRate = 2.0f;

    private void Start()
    {
        StartCoroutine(StartMovement());
    }

    private Vector3 DefinePosition()
    {
        int randomPoint = Random.Range(0, _startPositions.Count);

        return _startPositions[randomPoint].transform.position;
    }

    private void SpawnEnemy()
    {
        _spawnerEnemies.GetEnemy(DefinePosition());
    }

    private IEnumerator StartMovement()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (true)
        {
            SpawnEnemy();

            yield return wait;
        }
    }
}