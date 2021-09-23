using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferee : MonoBehaviour
{
    GameObject GameDirector;
    GameObject DeckController;
    public bool playertrun = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            Debug.Log("Enemy Win");
        }
    }
}
