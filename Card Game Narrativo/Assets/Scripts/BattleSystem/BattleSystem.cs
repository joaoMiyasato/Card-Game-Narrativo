using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST, STANDBY}

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    public GameObject battlePanel;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public GameObject dialogueField;
    public GameObject buttonField;
    private Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public  BattleState state;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = BattleState.STANDBY;
        dialogueText = dialogueField.transform.Find("Dialog").gameObject.GetComponent<Text>();
    }

    public void startBattle()
    {
        SpeachManager.instance.speechPanel.SetActive(false);
        battlePanel.SetActive(true);
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = " a wild " + enemyUnit.unitName + "approaches...";
        
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds (2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = " the attack is successful";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);
        dialogueText.text = enemyUnit.unitName + " attack!";

        yield return new WaitForSeconds(1F);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1F);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);
        if(state == BattleState.WON)
        {
            DialogManager.battleId = 0;
            dialogueText.text = "you won the battle";
        }
        else if(state == BattleState.LOST)
        {
            DialogManager.battleId = 1;
            dialogueText.text = "you were defeated";  
        }

        battlePanel.SetActive(false);
        SpeachManager.instance.speechPanel.SetActive(true);
        DialogManager.instance.Say();
    }

    void PlayerTurn()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);
        dialogueText.text = "Choose an action:";
        dialogueField.SetActive(false);
        buttonField.SetActive(true);
    }
    
    IEnumerator PlayerHeal()
    {
        buttonField.SetActive(false);
        dialogueField.SetActive(true);
        playerUnit.Heal(5);
        
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text ="you feel renewed strength";

        yield return new WaitForSeconds(2F);
        
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void onAttackButton()
    {
        if(state !=BattleState.PLAYERTURN)
            return;

            StartCoroutine(PlayerAttack());
    }


    public void onHealButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;

            StartCoroutine(PlayerHeal());
    }

}
