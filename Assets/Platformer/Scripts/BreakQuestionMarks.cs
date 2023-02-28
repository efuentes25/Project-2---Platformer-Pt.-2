using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakQuestionMarks : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mario") && collision.contacts[0].normal.y > 0.5f)
        {
            Destroy(gameObject);
            UIPoints.pointScore += 100;
            UIPoints.coinScore += 1;
        }
    }
}
