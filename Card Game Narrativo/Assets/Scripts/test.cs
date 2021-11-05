using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Unit player;

    private void Update()
    {
        player.damage = DeckManager.instance.currentCard.damage;
    }
}
