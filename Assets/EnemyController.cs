using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    GameObject GameDirector;
    GameObject FieldController;
    private HandController handController;
    public List<int> playershandNumber = new List<int>();

    private CardController card;
    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.FieldController = GameObject.Find("Playarea");
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
        card = handController.MoveCard(Cardnumbers_index);
        FieldController.GetComponent<FieldController>().card = this.card;
        card.transform.DOMove(new Vector3(360f, 200f, 0f), 1f);
        card.transform.DORotate(new Vector3(0, 180f,0), 0.05f).SetLoops(2,LoopType.Yoyo);
        GameObject Ura = card.transform.Find("imgUra").gameObject;
        Ura.SetActive(false);
    }

    public void OnCard(CardController obj)
    {
        this.FieldController.GetComponent<FieldController>().AddIsCard(obj);
    }
   
    public int ChooseCard()
    {
        return handController.GetlowestCardNumber();
    }
    private IEnumerator EnemyMoveCoroutine()
    {
        this.GameDirector.GetComponent<GameDirector>().Cardfill();
        yield return new WaitForSeconds(1f);
        PlayCard();
        yield return new WaitForSeconds(1f);
        GameDirector.GetComponent<GameDirector>().DecreaseCard(this.card);
        //ここのタイミングで効果を入れたい
       StartCoroutine(card.Effect(card.handNumber,FieldController.GetComponent<FieldController>().OnEfectEnd));
        //Debug.Log("効果発動");
    }
}
