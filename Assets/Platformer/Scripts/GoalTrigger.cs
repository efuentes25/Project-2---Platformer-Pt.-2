using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mario"))
        {
            StartCoroutine(waitSeconds());
        }
    }
    
    IEnumerator waitSeconds()
    {
        yield return new WaitForSeconds((float)1.7);
        Debug.Log($"You Win");
        Time.timeScale = 0;
    }
}
