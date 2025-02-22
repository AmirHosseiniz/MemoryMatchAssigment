using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCardsFactory : IGameCardsFactory
{
    private DiContainer _container;
    private CardView _cardViewPrefab;

    [Inject]
    private void Init(DiContainer container, CardView cardViewPrefab)
    {
        _container = container;
        _cardViewPrefab = cardViewPrefab;
    }
    
    public ICardView CreateGameCards(Transform parent)
    {
        return _container.InstantiatePrefab(_cardViewPrefab,parent).GetComponent<CardView>();
    }
}
