using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject FireBallPreFab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire6"))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        // make copies of the fireball.
        Instantiate(FireBallPreFab, FirePoint.position, FirePoint.rotation);
    }
}

