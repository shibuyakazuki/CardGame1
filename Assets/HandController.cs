using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HandController : MonoBehaviour
{
    private List<CardController> CardList = new List<CardController>();
    public List<int> NumberList = new List<int>();
    public GameObject LeftSide;
    public GameObject RightSide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCard(CardController card, int number)
    {
        CardList.Add(card);
        NumberList.Add(number);
        LineUp();
    }
    public void RemoveCard(CardController card)
    {
        CardList.Remove(card);
    }
    public void LineUp()
    {
        Vector3 PosLeft = LeftSide.GetComponent<RectTransform>().position;
        Vector3 PosDiff = RightSide.GetComponent<RectTransform>().position - PosLeft;
        Vector3 PosDelta = PosDiff / (CardList.Count + 1);
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].transform.SetParent(this.transform);
            Vector3 PosTarget = PosLeft + PosDelta * (i + 1);
            CardList[i].GetComponent<RectTransform>().DOMove(PosTarget, 0.25f);
        }
    }

    //ここからやる（タグで種類の判別を行う）
    /*public int ConvertListnumbers(CardController card)
    {
        int number;
        if ()
        {

        }
        return number;
    }*/

    public int CheckHandCard()
    {
        int cards = CardList.Count;
        return cards;
    }
    public CardController MoveCard(int index)
    {
        return CardList[index];
    }
}
