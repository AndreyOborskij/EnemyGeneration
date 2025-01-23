using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private DirectionGenerator _directionGenerator;
    [SerializeField] private WalkZone _walkZone;
    [SerializeField] private List<Transform> _startPositions;

    private ObjectPool<Enemy> _poolEnemies;
    private float _repeatRate = 2.0f;

    private void Awake()
    {
        _poolEnemies = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefabEnemy),
            actionOnGet: (enemy) => ActivateEnemy(enemy),
            actionOnRelease: (enemy) => DeactivateEnemy(enemy)
            );
    }

    private void OnEnable()
    {
        _walkZone.LeftZone += CameBackEnemy;
    }

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }
    
    private void OnDisable()
    {
        _walkZone.LeftZone -= CameBackEnemy;
    }

    private void GetEnemy()
    {
        _poolEnemies.Get();
    }

    public void CameBackEnemy(Enemy enemy)
    {
        _poolEnemies.Release(enemy);
    }

    private void ActivateEnemy(Enemy enemy)
    {
        PassStartPosition(enemy);

        enemy.ReceiveDirection(_directionGenerator.Create());

        enemy.gameObject.SetActive(true);
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void PassStartPosition(Enemy enemy)
    {
        enemy.transform.position = DetermineStartPosition();
    }

    private Vector3 DetermineStartPosition()
    {
        int randomPosition = Random.Range(0, _startPositions.Count);

        return _startPositions[randomPosition].position;
    }

    private IEnumerator StartSpawn()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (true)
        {
            GetEnemy();

            yield return wait;
        }
    }
}
