using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public bool isTouchGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchGround = true;
        Debug.Log($"go : {gameObject.name}, {transform.position}, collision : {collision.collider.name}, pos : {collision.transform.position}, {Time.frameCount}");
    }
}
