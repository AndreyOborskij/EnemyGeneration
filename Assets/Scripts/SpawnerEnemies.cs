using UnityEngine;
using UnityEngine.Pool;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Direction _direction;
    [SerializeField] private WalkZone _walkZone;

    private ObjectPool<Enemy> _poolEnemies;
    private Vector3 _startPosition;

    private void Awake()
    {
        _poolEnemies = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefabEnemy),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => ActionOnRelease(enemy)
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

    public void GetEnemy(Vector3 startPosition)
    {
        _startPosition = startPosition;

        _poolEnemies.Get();
    }

    public void ReturnEnemy(Enemy enemy)
    {
        _poolEnemies.Release(enemy);
    }

    private void ActionOnGet(Enemy enemy)
    {
        CreateDirection(enemy);

        enemy.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    public void CreateDirection(Enemy enemy)
    {
        Vector3 randomDirection = _direction.GetRandomDirection();

        enemy.transform.position = _startPosition;

        enemy.SetDirection(randomDirection);
    }
}
