using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "MemoryMatch/LevelConfig")]
public class MemoryMatchLevelConfig : ScriptableObject
{
    [Header("Grid Settings")]
    [SerializeField] private int gridX = 4;
    [SerializeField] private int gridY = 4;
    [SerializeField] private Vector2 spacing;    
    
    [Header("Card Settings")]
    [SerializeField] private Sprite cardsBack;
    [SerializeField] private Sprite[] cardSprites;
    
    public int GridX => gridX;
    public int GridY => gridY;
    public Vector2 Spacing => spacing;
    
    public Sprite[] CardSprites => cardSprites;
    public Sprite CardsBack => cardsBack;
}
