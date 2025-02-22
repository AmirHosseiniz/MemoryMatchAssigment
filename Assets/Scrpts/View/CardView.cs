using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardView : MonoBehaviour ,ICardView
{
    [SerializeField] private Button button;
    [SerializeField] private Image cardImage;

    private CardModel _model;
    private ICardSelectedAction _onCardSelected;
    private readonly float flipDuration = 0.15f;
    private Sprite _backSprite;

    public void Initialize(CardModel model, ICardSelectedAction onCardSelected)
    {
        this._model = model;
        this._onCardSelected = onCardSelected;
        cardImage.sprite = model.backSprite;
        _backSprite = model.backSprite;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        _onCardSelected?.OnCardSelected(this);
    }

    public void Reveal()
    {
        if(_model.isRevealed || _model.isMatched) return;
        button.interactable = false;
        cardImage.transform.DOScaleX(0, flipDuration).OnComplete(() =>
        {
            cardImage.sprite = _model.sprite;
            _model.isRevealed = true;
            cardImage.transform.DOScaleX(1, flipDuration);
        });
    }

    public void Hide()
    {
        if(!_model.isRevealed || _model.isMatched) return;
        button.interactable = false;
        cardImage.transform.DOScaleX(0, flipDuration).OnComplete(() =>
        {
            cardImage.sprite = _backSprite;
            _model.isRevealed = false;
            cardImage.transform.DOScaleX(1, flipDuration).OnComplete(() => button.interactable = true);
        });
    }

    public void MarkMatched()
    {
        _model.isMatched = true;
        cardImage.transform.DOScale(1.2f, 0.2f).OnComplete(() =>
        {
            cardImage.transform.DOScale(1f, 0.2f);
        });
        button.interactable = false;
    }

    public void ShakeCard()
    {
        cardImage.transform.DOShakePosition(0.35f, new Vector3(10f, 0, 0));
    }

    public int GetCardId()
    {
        return _model.id;
    }
}
