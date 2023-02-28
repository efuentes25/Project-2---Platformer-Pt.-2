using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakBreaks : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mario") && collision.contacts[0].normal.y > 0.5f)
        {
            Destroy(gameObject);
            UIPoints.pointScore += 100;
        }
    }
}