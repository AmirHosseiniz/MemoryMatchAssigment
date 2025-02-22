using UnityEngine;
using System.Collections.Generic;

public class MemoryMatchModel
{
    public List<CardModel> Cards = new();

    public void SetupCards(MemoryMatchLevelConfig levelConfig)
    {
        var totalCards = levelConfig.GridX * levelConfig.GridY;
        if (totalCards % 2 != 0)
        {
            Debug.LogError("Total cards must be even for pairing");
            return;
        }

        Cards.Clear();
        var pairs = totalCards / 2;
        for (var i = 0; i < pairs; i++)
        {
            Sprite sprite = levelConfig.CardSprites[i % levelConfig.CardSprites.Length];
            Cards.Add(new CardModel(i, sprite , levelConfig.CardsBack));
            Cards.Add(new CardModel(i, sprite,levelConfig.CardsBack));
        }

        for (var i = 0; i < Cards.Count; i++)
        {
            var temp = Cards[i];
            var randomIndex = Random.Range(i, Cards.Count);
            Cards[i] = Cards[randomIndex];
            Cards[randomIndex] = temp;
        }
    }
}
