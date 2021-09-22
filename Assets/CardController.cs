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
    private GameObject GameDirector;
    private GameObject GameReferee;
    private GameObject Playarea;
    private GameObject objUra;
    private bool Isbrind;

    public void OnDrag(PointerEventData eventData)
    {
        if (this.GameDirector.GetComponent<GameDirector>().OnCardFlag == false)
        {
            transform.Translate(eventData.delta);
            Debug.Log("Ondrag");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        Debug.Log("OnEndDrag");
        if (GameDirector.GetComponent<GameDirector>().OnCardFlag == false)
        {
            this.transform.DOMove(start_pos, 0.5f).SetLoops(1, LoopType.Yoyo);
        }
    }

    public void init(bool _isbrind)
    {
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
        this.GameDirector = GameObject.Find("GameDirector");
        this.GameReferee = GameObject.Find("GameReferee");
        this.Playarea = GameObject.Find("Playarea");
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
}
