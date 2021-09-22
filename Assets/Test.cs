using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start1");
        StartCoroutine(Call());
        Debug.Log("start2");
    }
    private IEnumerator Call()
    {
        Debug.Log("Call1");
        yield return new WaitForSeconds(3f);
        Debug.Log("Call2");
    }
}
