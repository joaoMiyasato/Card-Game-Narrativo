using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public List<DialogIns> DialogList;
    public List<ChoiceIns> ChoiceList;
    public Animator anim;
    public GameObject speakerOther;
    public Sprite[] NPCs;

    [HideInInspector]public int indexDialog = 0;
    [HideInInspector]public int indexDialogList = 0;
    [HideInInspector]public int indexDialogAnswer = 0;
    [HideInInspector]public DialogIns currendDialog;

    bool waitingForBattle = false;
    
    SpeachManager dialogue;

    [HideInInspector]public bool transition;

    private bool showCardsToPickBool;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        dialogue = SpeachManager.instance;
    }
    void Update()
    {
        currendDialog = DialogList[indexDialogList];
        if(Input.GetKeyDown(KeyCode.R))
        {
            indexDialog = 0;
            indexDialogAnswer = 0;
            indexDialogList = 0;
            Say();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(showCardsToPickBool)
            {
                showCardsToPickBool = false;
                DeckManager.instance.showCardsToPick();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && !DeckManager.instance.pickingCard)
        {
            startAnimation();

            if(AnswerManager.instance.inAnswer)
            {
                AnswerManager.instance.newSetAnswers(ChoiceList[indexDialogAnswer].Answer);
                AnswerManager.instance.answerPanel.SetActive(true);
            }

            if(waitingForBattle)
            {
                BattleSystem.instance.startBattle();
                waitingForBattle = false;
            }

            if(dialogue.waitingInput && !AnswerManager.instance.inAnswer && !BattleSystem.instance.inBattle && !transition || !dialogue.isSpeaking || /*retirar*/!waitingForBattle && !transition)
            {
                if(indexDialog >= DialogList[indexDialogList].Dialog.Length)
                {
                    return;
                }
                Say();
            }
        }
    }

    private string lastSpeaker = "";
    public void Say()
    {
        DialogList[indexDialogList].alreadySpoke = true;
        //0 Fala, 1 Nome, 2 o quê, 3 ir pra dialogo, 4 ir para pergunta, 5 animação, 6 e 7 batalha
        string[] parts = DialogList[indexDialogList].Dialog[indexDialog].Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2 && parts[1] != "") ? parts[1] : lastSpeaker;

        if(parts.Length >= 3)
        {
            if(parts[2] == "pergunta")
            {
                AnswerManager.instance.inAnswer = true;
            }
            else if(parts[2] == "batalha")
            {
                waitingForBattle = true;
            }
            else if(parts[2] == "cartas")
            {
                showCardsToPickBool = true;
            }
            else
            {

            }
        }
        if(parts.Length >= 5)
        {
            if(parts[4] != "")
            {
                setDialogAnswer(int.Parse(parts[4]));
            }
        }
        if(parts.Length >= 6)
        {
            if(parts[5] != "")
            {
                activateAnimation(int.Parse(parts[5]));
            }   
        }
        if(parts.Length >= 8)
        {
            if(parts[2] == "batalha")
            {
                //BattleSystem.instance.startBattle(int.Parse(parts[6]), int.Parse(parts[7]));
            }
        }

        if(lastSpeaker != speaker)
        {
            lastSpeaker = speaker;
        }

        if(lastSpeaker == "Azarys")
        {
            speakerOther.gameObject.SetActive(false);
            dialogue.speechPanel.transform.Find("DialogBox").gameObject.transform.Find("Image").transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            dialogue.speechPanel.transform.Find("DialogBox").gameObject.transform.Find("Image").transform.localScale = new Vector3(1,1,1);
            if(lastSpeaker == "Illana")
            {
                speakerOther.gameObject.SetActive(true);
                speakerOther.GetComponent<Image>().color = new Color32(255,255,255,255);
                speakerOther.GetComponent<Image>().sprite = NPCs[0];
            }
        }

        dialogue.Say(speech, speaker);
        indexDialog++;

        if(parts.Length >= 4)
        {
            if(parts[3] != "")
            {
                setDialogList(int.Parse(parts[3]));
            }
        }
    }

    public void setDialogList(int i)
    {
        indexDialog = 0;
        indexDialogList = i;
    }

    public void setDialogAnswer(int i)
    {
        indexDialogAnswer = i;
    }

    private string curAnim = "";
    private bool startAnim;
    private void activateAnimation(int i)
    {
        transition = true;
        startAnim = true;
        if(i == 0)
        {
            //Dia senguinte
            curAnim = "nextDay";
        }
        else if(i == 1)
        {
            //Próxima cena (fade)
            curAnim = "nextScene";
        }
    }
    private void startAnimation()
    {
        if(transition && startAnim)
        {
            anim.SetTrigger(curAnim);
            startAnim = false;
        }
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < DialogList.Count; i++)
        {
            DialogList[i].alreadySpoke = false;
        }
    }
}
