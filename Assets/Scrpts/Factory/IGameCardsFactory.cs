using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameCardsFactory
{
    ICardView CreateGameCards(Transform parent);
}
