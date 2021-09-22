using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    GameObject GameDirector;
    GameObject DeckController;
    GameObject FieldController;
    GameObject CardGenerator;
    GameObject Ereaenemyside;
    GameObject CardController;
    List<int> handnumbers = new List<int>();
    private int Cardnumber = 0;
    private CardController Card;
    public float OnCardTimer = 0f;
    public bool OnCardTimerStart = false;
    public float OnDropTimer = 0f;
    public bool OnDropTimeStart = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.DeckController = GameObject.Find("Deck");
        this.FieldController = GameObject.Find("Playarea");
        this.CardGenerator = GameObject.Find("CardGenerator");
        this.Ereaenemyside  = GameObject.Find("areaenemyside");
        this.CardController = GameObject.Find("Card");

    }

    // Update is called once per frame
    void Update()
    {
        if (OnCardTimerStart)
        {
            OnCardTimer += Time.deltaTime;
            if (OnCardTimer > 1f)
            {
                PlayCard(); 
            }
        }

        if (OnDropTimeStart)
        {
            OnDropTimer += Time.deltaTime;
            if (OnDropTimer > 3f)
            {
                OnCard(Card);
            }
        }
    }

    public void EnemyMove()
    {
        this.GameDirector.GetComponent<GameDirector>().Cardfill();
        OnCardTimerStart = true;
        
        // 低いカードを選ぶ
        //Cardnumbers_index = ChooseCard();
        //カードを場に出す
        //CardController Card = this.Ereaenemyside.GetComponent<HandController>().MoveCard(Cardnumbers_index);
        //Card.transform.DOMove(new Vector3(0f, 0f, 0f), 5f);
        //Cardnumbers_index = ChooseCard();

        //カードを場に出す
        //CardController Card = this.Ereaenemyside.GetComponent<HandController>().MoveCard(Cardnumbers_index);
        //Card.transform.DOMove(new Vector3(0f, 0f, 0f), 5f);
        
    }
    public void PlayCard()
    {
        int Cardnumbers_index = ChooseCard();
        Card = this.Ereaenemyside.GetComponent<HandController>().MoveCard(Cardnumbers_index);
        Card.transform.DOMove(new Vector3(360f, 200f, 0f), 2f);
        OnCardTimerStart = false;
        OnCardTimer = 0;
        OnDropTimeStart = true;
        
    }
    public void OnCard(CardController Card)
    {
        OnDropTimeStart = false;
        OnDropTimer = 0;
        this.FieldController.GetComponent<FieldController>().OnDropCard(Card);
        handnumbers.Remove(handnumbers[Cardnumber]);
    }
    public void ListUp(int number)
    {
        handnumbers.Add(number);
    }
    public int ChooseCard()
    {
        Cardnumber = 0;
        if (handnumbers[0] > handnumbers[1])
        {
            Debug.Log("index1");
            Cardnumber = 1;
        }
        else
        {
            Debug.Log("index0");
            Cardnumber = 0;
        }
        return Cardnumber;
    }
}
