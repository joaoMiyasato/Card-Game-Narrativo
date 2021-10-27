using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    public GameObject deckPanel;
    public CardIns currentCard = null;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void updateCurrentCard()
    {
        deckPanel.transform.Find("Deck").gameObject.transform.Find("CardName").gameObject.GetComponent<Text>().text = currentCard.cardName;
        deckPanel.transform.Find("Deck").gameObject.transform.Find("Damage").gameObject.GetComponent<Text>().text = currentCard.damage.ToString();
        deckPanel.transform.Find("Deck").gameObject.transform.Find("Defense").gameObject.GetComponent<Text>().text = currentCard.defense.ToString();
    }
    public void showCards()
    {
        deckPanel.transform.Find("Cards").gameObject.SetActive(true);
    }
    public void hideCards()
    {
        deckPanel.transform.Find("Cards").gameObject.SetActive(false);
    }
}
