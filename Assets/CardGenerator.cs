using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject[] CardPrefab;
    public Transform parentTrain;
    public List<GameObject> player_hands = new List<GameObject>();
    public List<GameObject> enemy_hands = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardController Generator(int index)
    {
        GameObject Card = Instantiate(CardPrefab[index]) as GameObject;
        Card.transform.SetParent(parentTrain,false);
        return Card.GetComponent<CardController>();

    }
}
