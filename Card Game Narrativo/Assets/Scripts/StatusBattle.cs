using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHUD2 : MonoBehaviour
{
      public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHp;

    public void TakeDamage(int dmg)
    {

      currentHP -= dmg;
      if(currentHP<= 0)
          return true;
      else 
          return false;
    } 
    
    public void Heal(int amount)
    {
      currentHP -= amount;
      if(currentHP > maxHP)
         current = maxHP;
    }

}
