using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mario"))
        {
            //Debug.Log($"we hit");
            StartCoroutine(waitSeconds());
        }
    }

    IEnumerator waitSeconds()
    {
        yield return new WaitForSeconds(3);
        //Debug.Log($"You Lose");
        UITimer.timeValue = 0;
    }
}
