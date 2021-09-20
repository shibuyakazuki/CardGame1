using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject GameDirector;
    GameObject DeckController;
    GameObject FieldController;
    GameObject CardGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.DeckController = GameObject.Find("Deck");
        this.FieldController = GameObject.Find("Playarea");
        this.CardGenerator = GameObject.Find("CardGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyMove()
    {
        this.GameDirector.GetComponent<GameDirector>().Cardfill();

    }
}
