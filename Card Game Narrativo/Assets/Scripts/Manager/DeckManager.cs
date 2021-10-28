using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    public GameObject deckPanel;
    public GameObject currentCardView;

    private void Awake()
    {
        instance = this;
    }
    public void updateCurrentCard(CardIns newCard)
    {
        currentCardView.transform.Find("CardName").gameObject.GetComponent<Text>().text = newCard.cardName;
        currentCardView.transform.Find("Damage").gameObject.GetComponent<Text>().text = newCard.damage.ToString();
        currentCardView.transform.Find("Defense").gameObject.GetComponent<Text>().text = newCard.defense.ToString();
    }
    public void showCards()
    {
        deckPanel.SetActive(true);
        deckPanel.transform.Find("Cards").gameObject.SetActive(true);
    }
    public void hideCards()
    {
        deckPanel.SetActive(false);
        deckPanel.transform.Find("Cards").gameObject.SetActive(false);
    }
}
