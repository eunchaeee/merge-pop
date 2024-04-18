using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public bool isTouchGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchGround = true;
    }
}
