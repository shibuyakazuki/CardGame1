using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FieldController : MonoBehaviour,IDropHandler
{
    private GameObject GameDirector;
    private GameObject LeftBox;
    public List<GameObject> IsCard = new List<GameObject>();
    public int count = 0;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (GameDirector.GetComponent<GameDirector>().OnCardFlag == false)
        {
            if (eventData.pointerDrag != null)
            {
                GameDirector.GetComponent<GameDirector>().OnCardFlag = true;
                IsCard.Add(eventData.pointerDrag);
                eventData.pointerDrag.gameObject.transform.SetParent(transform);
                count = IsCard.Count;
                float px = LeftBox.transform.position.x;
                for (var i = 0; i < count; i++)
                {
                    IsCard[i].transform.position = new Vector3(px + (i * 40), transform.position.y, 0);
                }
                GameDirector.GetComponent<GameDirector>().DecreaseCard(eventData.pointerDrag.GetComponent<CardController>());
                //Debug.Log("Decrease");
                this.GameDirector.GetComponent<GameDirector>().TrunEnd();
            }
        }
            /*if (eventData.pointerDrag != null)
            {
                GameDirector.GetComponent<GameDirector>().OnCardFlag = true;
                IsCard.Add(eventData.pointerDrag);
                eventData.pointerDrag.gameObject.transform.SetParent(transform);
                count = IsCard.Count;
                float px = LeftBox.transform.position.x;
                for (var i = 0; i < count; i++)
                {
                    IsCard[i].transform.position = new Vector3(px + (i * 40), transform.position.y, 0);
                }
                GameDirector.GetComponent<GameDirector>().DecreaseCard(eventData.pointerDrag.GetComponent<CardController>());
            }*/
    }

    public void OnDropCard(CardController Card)
    {
        IsCard.Add(Card.gameObject);
        Card.gameObject.transform.SetParent(transform);
        count = IsCard.Count;
        float px = LeftBox.transform.position.x;
        for (var i = 0; i < count; i++)
        {
            IsCard[i].transform.position = new Vector3(px + (i * 40), transform.position.y, 0);
        }
        GameDirector.GetComponent<GameDirector>().DecreaseCard(Card.gameObject.GetComponent<CardController>());
        this.GameDirector.GetComponent<GameDirector>().TrunEnd();
    }

        // Start is called before the first frame update
        void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.LeftBox = GameObject.Find("LeftBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
