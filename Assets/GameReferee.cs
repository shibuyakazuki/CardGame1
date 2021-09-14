using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferee : MonoBehaviour
{
    GameObject GameDirector;
    GameObject DeckController;
    public bool playertrun;
    

    // Start is called before the first frame update
    void Start()
    {
        playertrun = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrunChange()
    {
        playertrun = !playertrun;
    }
}
