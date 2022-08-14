using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller 
{
    public Transform PlayerSpawnPoint;
    public GameObject PlayerPrefab;
    public PlayerHealth PlayerHealth;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        PlayerController playerController = Container.InstantiatePrefabForComponent<PlayerController>(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
        Container.Bind<PlayerHealth>().FromInstance(PlayerHealth).AsSingle();
    }
}
