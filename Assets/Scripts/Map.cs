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

    public Vector3 DefinePosition()
    {
        int randomPoint = Random.Range(0, _startPositions.Count);

        return _startPositions[randomPoint].transform.position;
    }

    private void SpawnEnemy()
    {
        _spawnerEnemies.GetEnemy();
    }

    private IEnumerator StartMovement()
    {
        while (true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(_repeatRate);
        }
    }
}