using UnityEngine;

public class CardModel
{
    public int id;
    public Sprite sprite;
    public Sprite backSprite;
    public bool isRevealed;
    public bool isMatched;

    public CardModel(int id, Sprite sprite , Sprite backSprite)
    {
        this.id = id;
        this.sprite = sprite;
        this.backSprite = backSprite;
        isRevealed = false;
        isMatched = false;
    }
}
