using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller, IInitializable 
{
	public Transform PlayerSpawnPoint;
	public GameObject PlayerPrefab;
	public PlayerHealth PlayerHealth;
	public Transform[] SpawnPositions;

	public override void InstallBindings()
    {
        BindInstallerInterfaces();
        BindPlayer();
        BindEnemyFactory();
    }

    private void BindEnemyFactory()
    {
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
    }

    private void BindPlayer()
	{
		PlayerController playerController = Container.InstantiatePrefabForComponent<PlayerController>(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity, null);
		Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
		Container.Bind<PlayerHealth>().FromInstance(PlayerHealth).AsSingle();
	}

	private void BindInstallerInterfaces()
	{
		Container.BindInterfacesTo<LocationInstaller>().FromInstance(this).AsSingle();
	}

	public void Initialize()
	{
		var enemyFactory = Container.Resolve<IEnemyFactory>();
		enemyFactory.Load();

		foreach (Transform spawnPosition in SpawnPositions)
			enemyFactory.Create(spawnPosition.position);
	}

}
