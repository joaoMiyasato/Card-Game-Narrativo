using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardIns : CardObj
{
    public int ID;
    public string cardName;
    public string description;
    public int damage;
    public int defense;
}
