using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    public GameObject deckPanel;
    public GameObject currentCardView;
    public CardIns currentCard;

    public List<CardIns> deck;

    public GameObject[] CardPicked;

    [HideInInspector]public bool pickingCard;
    [HideInInspector]public bool full;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deck.Add(currentCard);
    }

    private void Update()
    {
        if(deck.Count >= 6)
        {
            full = true;
        }
    }

    public void updateSelectedCards()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardPicked[i].GetComponent<CardsButton>().card = deck[i];
        }
    }

    public void updateCurrentCard(CardIns newCard)
    {
        currentCard = newCard;
        currentCardView.transform.Find("CardName").gameObject.GetComponent<Text>().text = newCard.cardName;
        currentCardView.transform.Find("Damage").gameObject.transform.Find("TextN").GetComponent<Text>().text = newCard.damage.ToString();
        currentCardView.transform.Find("Defense").gameObject.transform.Find("TextN").GetComponent<Text>().text = newCard.defense.ToString();
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

    public CardIns cardSelected = null;
    public void showCardsToPick()
    {
        SpeachManager.instance.speechPanel.gameObject.SetActive(false);
        pickingCard = true;
        deckPanel.SetActive(true);
        deckPanel.transform.Find("AllCards").gameObject.SetActive(true);
        deckPanel.transform.Find("ConfirmarCartas").gameObject.SetActive(true);
    }
}
