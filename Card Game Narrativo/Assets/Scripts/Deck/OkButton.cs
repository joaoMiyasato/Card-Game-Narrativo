using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : MonoBehaviour
{
    public void OK()
    {
        Destroy(transform.parent.gameObject);
    }

    public void ConfirmarDeck()
    {
        DeckManager.instance.updateSelectedCards();
        DeckManager.instance.pickingCard = false;
        DeckManager.instance.deckPanel.SetActive(false);
        DeckManager.instance.deckPanel.transform.Find("AllCards").gameObject.SetActive(false);
        DeckManager.instance.deckPanel.transform.Find("ConfirmarCartas").gameObject.SetActive(false);
        DeckManager.instance.currentCardView.gameObject.SetActive(true);
        SpeachManager.instance.speechPanel.gameObject.SetActive(true);
    }
}
