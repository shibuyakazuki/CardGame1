using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FieldController : MonoBehaviour,IDropHandler
{
    private GameObject GameDirector;
    private GameObject LeftBox;
    public CardController card;
    public List<GameObject> IsCard = new List<GameObject>();
    public int count = 0;
    public bool secondcard_6 = false;
    public void OnEfectEnd()
    {
        Debug.Log("EfectEnd");
        AddIsCard(this.card);
    }

    public void OnDrop(PointerEventData eventData)//カードが置かれた
    {
        if (GameDirector.GetComponent<GameDirector>().OnCardFlag == false)
        {
            if (eventData.pointerDrag != null)
            {
                GameDirector.GetComponent<GameDirector>().DecreaseCard(eventData.pointerDrag.GetComponent<CardController>());
                //効果を発動して
                card = eventData.pointerDrag.GetComponent<CardController>();
                StartCoroutine(eventData.pointerDrag.GetComponent<CardController>().Effect(
                    eventData.pointerDrag.GetComponent<CardController>().handNumber,OnEfectEnd));
                GameDirector.GetComponent<GameDirector>().OnCardFlag = true;
            }
        }
    }

    public void AddIsCard(CardController _card)
    {
        IsCard.Add(_card.gameObject);
        _card.transform.SetParent(transform);
        count = IsCard.Count;
        float px = LeftBox.transform.position.x;
        for (var i = 0; i < count; i++)
        {
            IsCard[i].transform.position = new Vector3(px + (i * 40), transform.position.y, 0);
        }
        this.GameDirector.GetComponent<GameDirector>().TrunEnd();
    }

    //IsCardリストのなかに指定した番号が何枚あるか返すメゾット
    public int CountTheNumber(int targetnumber)
    {
        int countnumber = 0;
        for (var i = 0; i < IsCard.Count; i++)
        {
            if (targetnumber == IsCard[i].gameObject.GetComponent<CardController>().handNumber)
            {
                countnumber += 1;
            }
        }
        return countnumber;
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
