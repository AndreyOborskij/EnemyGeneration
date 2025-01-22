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
        StartCoroutine(StartSpawn());
    }

    private Vector3 SetStartPosition()
    {
        int randomPosition = Random.Range(0, _startPositions.Count);

        return _startPositions[randomPosition].position;
    }

    private void SpawnEnemy()
    {
        _spawnerEnemies.GetStartPosition(SetStartPosition());
        _spawnerEnemies.GetEnemy();
    }

    private IEnumerator StartSpawn()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (true)
        {
            SpawnEnemy();

            yield return wait;
        }
    }
}