using UnityEngine;

/// <summary>
/// Класс, создающий врагов на сцене.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private int _enemiesCount = 6;
    [SerializeField] private int _randomRadius = 8;
    [SerializeField] private float _enemyRadius = 1;

    private ColorsProvider _colorsProvider;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;

        for (var i = 0; i < _enemiesCount; i++)
        {
            var position = PositionGenerator.GetRandomPosition(_randomRadius);

            while (position.HasCollisions(_enemyRadius))
            {
                position = PositionGenerator.GetRandomPosition(_randomRadius);
            }

            var enemy = Instantiate(_enemyPrefab);

            enemy.transform.position = position;
            enemy.Initialize(_colorsProvider.GetColor());
        }
    }
}