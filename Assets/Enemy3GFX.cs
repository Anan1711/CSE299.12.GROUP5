using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; // new namespace whenever we use programming with star

public class Enemy3GFX : MonoBehaviour
{
    public AIPath aiPath; // public variable of the script

    //update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x <= -0.01f)
        // value positive so right shift 
        // desired velocity - with what velocity will the enemy travel 
        // x - hrizontal value greater than 0.01 

        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            // when moving right
            // -1f - negative on x
            //1f - on y
            //1f - on z
        }

        else if (aiPath.desiredVelocity.x >= 0.01f)

        // value negative so left shift
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            //moving left so we flip the values of x - we are flipping accordin to the x speed
        }

    }
}