using UnityEngine;
using UnityEngine.Pool;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private DirectionGenerator _directionGenerator;
    [SerializeField] private WalkZone _walkZone;

    private ObjectPool<Enemy> _poolEnemies;
    private Vector3 _startPosition;

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
        _walkZone.LeftZone += ReturnEnemy;
    }
    
    private void OnDisable()
    {
        _walkZone.LeftZone -= ReturnEnemy;
    }

    public void GetEnemy()
    {
        _poolEnemies.Get();
    }

    public void ReturnEnemy(Enemy enemy)
    {
        _poolEnemies.Release(enemy);
    }

    public void GetStartPosition(Vector3 startPosition)
    {
        _startPosition = startPosition;
    }

    private void ActivateEnemy(Enemy enemy)
    {
        SetStartPosition(enemy);

        enemy.GetDirection(_directionGenerator.Create());

        enemy.gameObject.SetActive(true);
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void SetStartPosition(Enemy enemy)
    {
        enemy.transform.position = _startPosition;
    }
}