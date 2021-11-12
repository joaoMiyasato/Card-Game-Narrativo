using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsButton : MonoBehaviour
{
    public int buttonId;
    public CardIns card;

    private void Update()
    {
        if(card != null)
        {
            this.transform.Find("CardName").gameObject.GetComponent<Text>().text = card.cardName;
            this.transform.Find("Description").gameObject.GetComponent<Text>().text = card.description;
            this.transform.Find("Damage").gameObject.GetComponent<Text>().text = card.damage.ToString();
            this.transform.Find("Defense").gameObject.GetComponent<Text>().text = card.defense.ToString();
        }
    }

    public void buttonClicked()
    {
        DeckManager.instance.updateCurrentCard(this.card);
        DeckManager.instance.hideCards();
        DeckManager.instance.deckPanel.SetActive(false);
    }

    public GameObject ConfirmButton;
    public void selectCard()
    {
        DeckManager.instance.cardSelected = this.card;
        GameObject Confirm = Instantiate(ConfirmButton, DeckManager.instance.deckPanel.transform);
    }
}
