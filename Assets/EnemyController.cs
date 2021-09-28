using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    GameObject GameDirector;
    GameObject FieldController;
    //GameObject Ereaenemyside;
    //GameObject AreaEnemySide;
    private HandController handController;

    //private int Cardnumber = 0;
    private CardController Card;
    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.FieldController = GameObject.Find("Playarea");
        //this.Ereaenemyside  = GameObject.Find("areaenemyside");
        //this.AreaEnemySide = GameObject.Find("areaenemyside");
        handController = GameObject.Find("areaenemyside").GetComponent<HandController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyMove()
    {
        StartCoroutine(EnemyMoveCoroutine());
    }
    public void PlayCard()
    {
        int Cardnumbers_index = ChooseCard();
        Card = handController.MoveCard(Cardnumbers_index);
        Card.transform.DOMove(new Vector3(360f, 200f, 0f), 1f);
        Card.transform.DORotate(new Vector3(0, 180f,0), 0.05f).SetLoops(2,LoopType.Yoyo);
        GameObject Ura = Card.transform.Find("imgUra").gameObject;
        Ura.SetActive(false);
    }

    public void OnCard(CardController obj)
    {
        this.FieldController.GetComponent<FieldController>().OnDropCard(obj);
    }
   
    public int ChooseCard()
    {
        return handController.GetlowestCardNumber();
        /*int Cardnumber = 0;
        Debug.Log("choose0");
        int handnumber0 = AreaEnemySide.GetComponent<HandController>().NumberList[0];
        int handnumber1 = AreaEnemySide.GetComponent<HandController>().NumberList[1];
        Debug.Log("choose1");
        if (handnumber0 >= handnumber1)
        {
            Cardnumber = 1;
        }
        else
        {
            Cardnumber = 0;
        }
        return Cardnumber;*/
    }
    private IEnumerator EnemyMoveCoroutine()
    {
        this.GameDirector.GetComponent<GameDirector>().Cardfill();
        yield return new WaitForSeconds(1f);
        PlayCard();
        yield return new WaitForSeconds(3f);
        OnCard(this.Card);
    }
}
