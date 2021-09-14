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
        this.GameReferee.GetComponent<GameReferee>().playertrun = false;
        Enemytrun();
        int x;
        var rand = new System.Random();
        x = rand.Next(0, 2);
        if (x == 0)
        {
            this.GameReferee.GetComponent<GameReferee>().playertrun = true;
        }
        else
        {
            this.GameReferee.GetComponent<GameReferee>().playertrun = false;
        }
        Debug.Log("start");
        Debug.Log("test01");
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
    public void DecreaseCard(CardController card)
    {
        Debug.Log("Generator");
        eiterhand.RemoveCard(card);
        this.GameReferee.GetComponent<GameReferee>().TrunChange();
        //Enemytrun();
    }
    public void Cardfill()
    {
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
            if (Cardnumber >= 0)
            {
                CardController Card = CardGenerator.GetComponent<CardGenerator>().Generator(Cardnumber);
                eiterhand.AddCard(Card);
            }
        }
    }
    public void Enemytrun()
    {
        if (this.GameReferee.GetComponent<GameReferee>().playertrun == false)
        {
            this.EnemyController.GetComponent<EnemyController>().EnemyMove();
        }
    }
    public void Enemyhandfill(CardController card)
    {
        enemyhand.AddCard(card);
    }

}
