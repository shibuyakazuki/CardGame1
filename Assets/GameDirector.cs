using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject DeckController;
    GameObject CardGenerator;
    //GameObject GameReferee;
    GameReferee gameReferee;
    GameObject EnemyController;
    public HandController playerhand;
    public HandController enemyhand;
    public bool OnCardFlag = false;
    public bool playertrun = false;
    //public bool enablefill = true;
    int[] index_Array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // Start is called before the first frame update
    void Start()
    {
        this.DeckController = GameObject.Find("Deck");
        this.CardGenerator = GameObject.Find("CardGenerator");
        gameReferee = GameObject.Find("GameReferee").GetComponent<GameReferee>();
        this.EnemyController = GameObject.Find("EnemyController");
        Cardfill();
        playertrun = !playertrun;
        Cardfill();
        StartCoroutine(DicideTrun());
        //TrunStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DicideTrun()
    {
        var rand = new System.Random();
        int number = rand.Next(0,2);
        Debug.Log("number" + number);
        if (number == 0)
        {
            playertrun = true;
        }
        else
        {
            playertrun = false;
        }

        yield return new WaitForSeconds(1f);
        TrunStart();
    }

    public int ArrayIndex(int number)
    {
        int target = number;
        int i = 0;
        while(i < 10)
        {
            if (target == index_Array[i])
            {
                break;
            }
            else
            {
                i = i + 1;
            }
        }

        return i;
    }
    public void RefreshOnCardFlag()
    {
        OnCardFlag = false;
    }
    public void DecreaseCard(CardController card)
    {
        if (playertrun)
        {
            playerhand.RemoveCard(card);
        }
        else
        {
            enemyhand.RemoveCard(card);
        }
    }
    public void Cardfill()
    {
        if (playertrun)
        {
            OnCardFlag = false;
        }
        int hands = 0;
        if (playertrun)
        {
            hands = playerhand.GetComponent<HandController>().CheckHandCard();
        }
        else
        {
            hands = enemyhand.GetComponent<HandController>().CheckHandCard();
        }
        
        if(hands < 2)
        {
            Debug.Log(DeckController);
            Debug.Log(DeckController.GetComponent<DeckController>());
            int handnumber = DeckController.GetComponent<DeckController>().DrawCard();
            CardController Card = CardGenerator.GetComponent<CardGenerator>().Generator(handnumber,!playertrun);
            if (playertrun)
            {
                playerhand.AddCard(Card);
            }
            else
            {
                enemyhand.AddCard(Card);
            }
        }
    }

    public void TrunStart() //ターン開始時の確認メゾット
    {
        if (this.DeckController.GetComponent<DeckController>().RemainingDeck() == 0)
        {
            int player_handnumber = playerhand.GethighestHandNumber();
            int enemy_handnumber = enemyhand.GethighestHandNumber();
            GAMERESULT result = gameReferee.judg(player_handnumber, enemy_handnumber);
            if (result == GAMERESULT.WIN)
            {

            }
            else if (result == GAMERESULT.LOSE)
            {

            }
            else
            {

            }
        }
        else
        {
            if (!playertrun)
            {
                this.EnemyController.GetComponent<EnemyController>().EnemyMove();
            }
            else
            {
                Cardfill();
            }
        }
    }
    public void TrunEnd() //ターンの終わりを確認する
    {
        playertrun = !playertrun;
        TrunStart();
    }
}
