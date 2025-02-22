using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardSelectedAction
{
    void OnCardSelected(ICardView selectedCard);
}
