using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState{ START , PLAYERTURN, ENEMYTURN, WON, LOS}

public class battleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public  BattleState state;


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, playerBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = " a wild " + enemyUnit.unitName + "approaches...";
        
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitforSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();




    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = " the attack is successful";

        yield return new WaitforSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();

        }else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attack!";
        yield return new WaitforSeconds(1F);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHp);

       yield return new WaitforSeconds(1F);

       if(isDead)
       {
           state = battleState.Lost;
           EndBattle();
       }else
       {
           state = BattleState.PLAYERTURN;
           playerTurn();
       }
        
    }
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "you won the battle";

        }else if(state == BattleState.LOST)
        {
          dialogueText.text = "you were defeated";  
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }
    
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text ="you feel renewed strength";

        yield return new WaitforSeconds(2F);
        
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    void onAttackButton()
    {
        if(state !=BattleState.PLAYERTURN)
           return;

           StartCoroutine(PlayerAttack());
    }


    void onHealButton()
    {
        if(state !=BattleState.PLAYERTURN)
           return;

           StartCoroutine(PlayerHeal());
    }

}
