using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GAMERESULT
{
    DRAW,
    WIN,
    LOSE,
};
public class GameReferee : MonoBehaviour
{ 
    GameObject ResultText;
    public bool playertrun = true;
    

    // Start is called before the first frame update
    void Start()
    {
        this.ResultText = GameObject.Find("ResultText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GAMERESULT judg(int playerhand, int enemyhand)
    {
        if (playerhand == enemyhand)
        {
            Debug.Log("Draw");
            return GAMERESULT.DRAW;
        }
        else if (playerhand > enemyhand)
        {
            Debug.Log("Player Win");
            this.ResultText.GetComponent<Text>().text = "You Win !!";
            return GAMERESULT.WIN;
        }
        else
        {
            Debug.Log("Enemy Win");
            this.ResultText.GetComponent<Text>().text = "You Lose";
            return GAMERESULT.LOSE;
        }
    }
}
