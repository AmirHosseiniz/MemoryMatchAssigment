using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private MemoryMatchLevelConfig _memoryMatchLevelConfig;
    [SerializeField] private CardView _cardViewPrefab;
    public override void InstallBindings()
    {
        Container.Bind<MemoryMatchLevelConfig>().FromInstance(_memoryMatchLevelConfig).AsSingle();
        Container.Bind<IGameCardsFactory>().To<GameCardsFactory>().AsSingle();
        Container.Bind<CardView>().FromInstance(_cardViewPrefab).AsSingle();
    }
}
