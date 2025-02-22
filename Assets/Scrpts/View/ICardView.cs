using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardView
{
    void Initialize(CardModel model, ICardSelectedAction onCardSelected);
    void Reveal();
    void Hide();
    void ShakeCard();
    int GetCardId();
    void MarkMatched();
}
