using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardsSelectedAction : ICardSelectedAction
{
    private bool _isProcessing;
    private ICardView _firstRevealed;

    public void OnCardSelected(ICardView selectedCard)
    {
        if (_isProcessing || selectedCard == null)
            return;

        if (selectedCard == _firstRevealed)
            return;

        selectedCard.Reveal();

        if (_firstRevealed == null)
        {
            _firstRevealed = selectedCard;
        }
        else
        {
            _isProcessing = true;
            if (_firstRevealed.GetCardId() == selectedCard.GetCardId())
            {
                DOTween.Sequence().AppendInterval(0.5f).OnComplete(() =>
                {
                    _firstRevealed.MarkMatched();
                    selectedCard.MarkMatched();
                    _firstRevealed = null;
                    _isProcessing = false;
                });
            }
            else
            {
                DOTween.Sequence().SetDelay(0.5f).OnComplete(() =>
                {
                    _firstRevealed.ShakeCard();
                    selectedCard.ShakeCard();
                    DOTween.Sequence().AppendInterval(0.5f).OnComplete(() =>
                    {
                        _firstRevealed.Hide();
                        selectedCard.Hide();
                        _firstRevealed = null;
                        _isProcessing = false;
                    });
                });
            }
        }
    }
}
