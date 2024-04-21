using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private UnityEvent<Fruit, Collision2D> collisionMessenger;

    public int Level { get; private set; }
    public bool IsTouched { get; private set; }


    public void SetFruitInfo(FruitInfo info)
    {
        Level = info.level;
        gameObject.name = info.name;
        spriteRenderer.color = info.color;
        transform.localScale = Vector3.one * info.scale;
    }

    public void InjectCollisionMessenger(CollisionMessenger messenger)
    {
        collisionMessenger = messenger.CollisionEvent;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsTouched = true;

        if (collision.gameObject.TryGetComponent(out Fruit f))
        {
            if (Level == f.Level)
            {
                collisionMessenger.Invoke(this, collision);
            }
        }
    }
}
