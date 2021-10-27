using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsButton : MonoBehaviour
{
    public int buttonId;
    public CardIns card;

    private void Start()
    {
        this.transform.Find("CardName").gameObject.GetComponent<Text>().text = card.cardName;
        this.transform.Find("Description").gameObject.GetComponent<Text>().text = card.description;
        this.transform.Find("Damage").gameObject.GetComponent<Text>().text = card.damage.ToString();
        this.transform.Find("Defense").gameObject.GetComponent<Text>().text = card.defense.ToString();
    }

    public void buttonClicked()
    {
        DeckManager.instance.currentCard = this.card;
        DeckManager.instance.updateCurrentCard();
        DeckManager.instance.hideCards();
    }
}
