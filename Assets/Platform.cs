using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform child;

    [SerializeField]
    private Transform transformB;

    void Start ()
    {
        posA = child.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    void Update ()
    {
        Move();
    }

    private void Move ()
    {
        child.localPosition = Vector3.MoveTowards(child.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(child.localPosition, nextPos) <= 0.1)
        {
            ChangeDest();
        }
    }

    private void ChangeDest()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
