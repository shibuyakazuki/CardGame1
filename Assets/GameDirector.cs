using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject DeckController;
    GameObject CardGenerator;
    GameObject GameReferee;
    GameObject EnemyController;
    public HandController playerhand;
    public HandController enemyhand;
    public bool OnCardFlag = false;
    int[] index_Array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private HandController eiterhand;

    // Start is called before the first frame update
    void Start()
    {
        this.DeckController = GameObject.Find("Deck");
        this.CardGenerator = GameObject.Find("CardGenerator");
        this.GameReferee = GameObject.Find("GameReferee");
        this.EnemyController = GameObject.Find("EnemyController");
       Cardfill();
        this.GameReferee.GetComponent<GameReferee>().playertrun = true;
        Cardfill();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Generator");
        eiterhand.RemoveCard(card);
    }
    public void Cardfill()
    {
        if (this.GameReferee.GetComponent<GameReferee>().playertrun)
        {
            OnCardFlag = false;
        }
        int hands = 0;
        if (this.GameReferee.GetComponent<GameReferee>().playertrun)
        {
            eiterhand = playerhand;
        }
        else
        {
            eiterhand = enemyhand;
        }

        hands = eiterhand.GetComponent<HandController>().CheckHandCard();
        if(hands < 2)
        {
            Debug.Log(DeckController);
            Debug.Log(DeckController.GetComponent<DeckController>());
            int Cardnumber = DeckController.GetComponent<DeckController>().DrawCard();
            if (eiterhand == enemyhand)
            {
                this.EnemyController.GetComponent<EnemyController>().ListUp(Cardnumber);
            }
            if (Cardnumber >= 0)
            {
                CardController Card = CardGenerator.GetComponent<CardGenerator>().Generator(Cardnumber);
                eiterhand.AddCard(Card);
            }
        }
    }

    public void TrunStart() //ターン開始時の確認メゾット
    {
        //OnCardFlag = false; ここでfalseにすると変な動きをする
        if (GameReferee.GetComponent<GameReferee>().playertrun == false)
        {
            Debug.Log("a");
            this.EnemyController.GetComponent<EnemyController>().EnemyMove();
        }
    }
    public void TrunEnd() //ターンの終わりを確認する
    {
        this.GameReferee.GetComponent<GameReferee>().TrunChange();
        TrunStart();
    }

    /*public void Enemytrun()
    {
        if (this.GameReferee.GetComponent<GameReferee>().playertrun == false)
        {
            this.EnemyController.GetComponent<EnemyController>().EnemyMove();
        }
    }
    public void Enemyhandfill(CardController card)
    {
        enemyhand.AddCard(card);
    }*/

}
