using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public UnityEvent onCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpperObstacle") || collision.gameObject.CompareTag("LowerObstacle"))
        {
            onCollision.Invoke();
        }
    }
}


