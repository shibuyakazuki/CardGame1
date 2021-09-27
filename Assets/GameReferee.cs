using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void judg(List<int> playerhand, List<int> enemyhand)
    {
        if (playerhand[0] == enemyhand[0])
        {
            Debug.Log("Draw");
        }
        else if (playerhand[0] > enemyhand[0])
        {
            Debug.Log("Player Win");
            this.ResultText.GetComponent<Text>().text = "You Win !!";
        }
        else
        {
            Debug.Log("Enemy Win");
            this.ResultText.GetComponent<Text>().text = "You Lose";
        }
    }
}
