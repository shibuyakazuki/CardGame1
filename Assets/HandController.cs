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
    public void AddCard(CardController card)
    {
        CardList.Add(card);
       // NumberList.Add(number);
        LineUp();
    }
    public void RemoveCard(CardController card)
    {
        CardList.Remove(card);
        //int number = ConvertListnumbers(card);
        //NumberList.Remove(number);
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

    public int GetlowestCardNumber()
    {
        int ret = 0;
        int min = 11;
        for (var i = 0; i < CardList.Count; i++)
        {
            int x = CardList[i].handNumber;
            if (min >= x)
            {
                min = x;
                ret = i;
            }
        }
        return ret;
    }

    public int GethighestHandNumber()
    {
        int max = 0;
        for (var i = 0; i < CardList.Count; i++)
        {
            int x = CardList[i].handNumber;
            if (max < x)
            {
                max = x;
            }
        }
        return max;
    }

    public int ConvertListnumbers(CardController card)
    {
        int number;
        if (card.gameObject.tag == "1")
        {
            number = 1;
        }
        else if (card.gameObject.tag == "2" )
        {
            number = 2;
        }
        else if (card.gameObject.tag == "3")
        {
            number = 3;
        }
        else if (card.gameObject.tag == "4")
        {
            number = 4;
        }
        else if (card.gameObject.tag == "5")
        {
            number = 5;
        }
        else if (card.gameObject.tag == "6")
        {
            number = 6;
        }
        else if (card.gameObject.tag == "7")
        {
            number = 7;
        }
        else if (card.gameObject.tag == "8")
        {
            number = 8;
        }
        else if (card.gameObject.tag == "9")
        {
            number = 9;
        }
        else
        {
            number = 10;
        }
            return number;
    }

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
