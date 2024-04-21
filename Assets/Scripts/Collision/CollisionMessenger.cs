using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CollisionMessenger", menuName = "ScriptableObject/CollisionMessenger")]
public class CollisionMessenger : ScriptableObject
{
    public UnityEvent<Fruit, Collision2D> CollisionEvent;
}

