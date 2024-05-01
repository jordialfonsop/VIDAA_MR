using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHeartApplication : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject heartPivot;

    private bool isExecuted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExecuted)
        {
            StartCoroutine(Wait(1));
            heartPivot.SetActive(false);
            heartPivot.GetComponent<UIOnEnableLocation>().enabled = true;
            isExecuted = true;
        }
    }

    IEnumerator Wait(int seconds)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(seconds);
    }
}
