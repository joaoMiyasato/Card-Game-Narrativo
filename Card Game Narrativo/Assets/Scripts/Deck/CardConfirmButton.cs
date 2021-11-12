using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConfirmButton : MonoBehaviour
{
    public CardIns cardToPick;
    public GameObject DeckFullError;
    public GameObject CardAlreadyTaken;
    private void Start()
    {
        cardToPick = DeckManager.instance.cardSelected;
    }
    public void confirmarButton()
    {
        if(DeckManager.instance.full)
        {
            GameObject Error = Instantiate(DeckFullError, DeckManager.instance.deckPanel.transform);
        }
        else
        {
            if(!DeckManager.instance.deck.Contains(cardToPick))
            {
                DeckManager.instance.deck.Add(cardToPick);
            }
            else
            {
                GameObject Error = Instantiate(CardAlreadyTaken, DeckManager.instance.deckPanel.transform);
            }
        }
        Destroy(transform.parent.gameObject);
    }

    public void negarButton()
    {
        Destroy(transform.parent.gameObject);
    }
}
