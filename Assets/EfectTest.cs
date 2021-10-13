using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(1f);
        Debug.Log("CallWaitTest");
        yield return StartCoroutine(WaitTest());
        Debug.Log("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator WaitTest()
    {
        Debug.Log("WaitTestStart");
        yield return new WaitForSeconds(1f);
        Debug.Log("WaitTestEnd");
    }
}
