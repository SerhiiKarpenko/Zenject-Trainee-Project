using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class EnemyFactory : IEnemyFactory
{
	private Object _enemyPrefab;
	private const string _enemy = "Enemy";
	private readonly DiContainer _diContainter;

	public EnemyFactory(DiContainer diContainer)
    {
		_diContainter = diContainer;
    }

	public void Load()
	{
		_enemyPrefab = Resources.Load(_enemy);
	}

	public void Create(Vector3 at)
	{
		_diContainter.InstantiatePrefab(_enemyPrefab, at, Quaternion.identity, null);
	}
}
