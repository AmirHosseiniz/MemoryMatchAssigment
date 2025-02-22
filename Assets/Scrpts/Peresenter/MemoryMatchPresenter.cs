using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using Zenject;

public class MemoryMatchPresenter : MonoBehaviour
{
    [SerializeField] private RectTransform cardContainer;        
    [SerializeField] private GridLayoutGroup gridLayoutGroup;    

    private MemoryMatchLevelConfig _levelConfig; 
    
    private MemoryMatchModel _model;
    private List<ICardView> _cardViews = new();

    private ICardSelectedAction _cardSelectedAction;
    private IGameCardsFactory _gameCardsFactory;
    
    [Inject]
    private void Init(MemoryMatchLevelConfig config,IGameCardsFactory gameCardsFactory)
    {
        _levelConfig = config;
        _gameCardsFactory = gameCardsFactory;
    }
    
    void Start()
    {
        _model = new MemoryMatchModel();
        _model.SetupCards(_levelConfig);
        SetupGrid();
        CreateCards();
    }

    void SetupGrid()
    {
        var containerRect = cardContainer.GetComponent<RectTransform>();
        var width = containerRect.rect.width;
        var height = containerRect.rect.height;
        var gridX = _levelConfig.GridX;
        var gridY = _levelConfig.GridY;

        var spacing = _levelConfig.Spacing;
        gridLayoutGroup.spacing = _levelConfig.Spacing;

        var totalHorizontalSpacing = spacing.x * (gridX - 1);
        var totalVerticalSpacing = spacing.y * (gridY - 1);

        var cellWidth = (width - totalHorizontalSpacing) / gridX;
        var cellHeight = (height - totalVerticalSpacing) / gridY;

        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridX;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }

    void CreateCards()
    {
        _cardSelectedAction = new CardsSelectedAction();
        
        foreach (var cardModel in _model.Cards)
        {
            var card = _gameCardsFactory.CreateGameCards( cardContainer);
            card.Initialize(cardModel, _cardSelectedAction);
            _cardViews.Add(card);
        }
    }
}
