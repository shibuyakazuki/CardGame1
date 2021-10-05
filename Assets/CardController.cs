using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class CardController : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerClickHandler
{
    Vector2 start_pos;
    //private GameObject GameDirector;
    private GameDirector gameDirector;
    private FieldController fieldController;
    private HandController enemyhand;
    private GameObject objUra;
    private bool Isbrind;
    public int handNumber;

    public void OnDrag(PointerEventData eventData)
    {
        if (gameDirector.OnCardFlag == false)
        {
            transform.Translate(eventData.delta);
            Debug.Log("Ondrag");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        Debug.Log("OnEndDrag");
        if (gameDirector.OnCardFlag == false)
        {
            this.transform.DOMove(start_pos, 0.5f).SetLoops(1, LoopType.Yoyo);
        }
    }

    public void init(int _handnumber, bool _isbrind)
    {
        handNumber = _handnumber;
        Isbrind = _isbrind;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = false;
        Debug.Log("OnBeginDrag");

        start_pos = transform.position;
    }

    public void Open()
    {
        objUra.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.GameDirector = GameObject.Find("GameDirector");
        this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        this.fieldController = GameObject.Find("Playarea").GetComponent<FieldController>();
        this.enemyhand = GameObject.Find("areaenemyside").GetComponent<HandController>();
        objUra = transform.Find("imgUra").gameObject;
        if (objUra != null)
        {
            objUra.SetActive(Isbrind);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Effect(int handnumber)
    {
        if (handnumber == 1)
        {
            Debug.Log("Effect1");
        }
        else if (handnumber == 2)
        {
            Debug.Log("Effect2");
        }
        else if (handnumber == 3)
        {
            Debug.Log("Effect3");
        }
        else if (handnumber == 4)
        {
            Debug.Log("Effect4");
        }
        else if (handnumber == 5)
        {
            Debug.Log("Effect5");
        }
        else if (handnumber == 6)
        {
            FieldController fieldController = GameObject.Find("Playarea").GetComponent<FieldController>();
            int count_6 = fieldController.CountTheNumber(6);
            if (count_6 == 0)
            {
                Debug.Log("カードを見せ合う");
                enemyhand.TrunCard();
                Invoke("enemyhand.OverCard",3f);
            }
            else
            {
                Debug.Log("対決");
                fieldController.secondcard_6 = true;
            }
        }
        else if (handnumber == 7)
        {
            Debug.Log("Effect7");
        }
        else if (handnumber == 8)
        {
            Debug.Log("Effect8");
        }
        else if (handnumber == 9)
        {
            Debug.Log("Effect9");
        }
        else
        {
            Debug.Log("Effect10");
        }
    }
}
