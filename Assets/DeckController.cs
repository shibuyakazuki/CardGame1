using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    private int[] deck
        = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 10 }; //山札の配列

    private int count = 0;
    GameObject GameDirector;
    GameObject GameReferee;

     private List<int> CallNumber = new List<int>(); //0~17までのdeckのインデックス番号を表したリスト

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < deck.Length; i++)
        {
            CallNumber.Add(i);
        }
        this.GameDirector = GameObject.Find("GameDirector");
        this.GameReferee = GameObject.Find("GameReferee");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public int DrawCard() //引いたカードを表すメゾット
    {
        int ret = 0;
        var rand = new System.Random();
        int ListIndex = rand.Next(0, 18 - count);
        int ArrayIndex = CallNumber[ListIndex];
        CallNumber.RemoveAt(ListIndex);
        //Debug.Log(deck[ArrayIndex]);
        ret = deck[ArrayIndex];
        count += 1;
        return ret;
    }
    public int RemainingDeck()
    {
        int remainingnumber = CallNumber.Count;
        return remainingnumber;
    }
}
