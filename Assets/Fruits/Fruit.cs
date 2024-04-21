using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int level;

    public bool isTouchGround = false;

    [SerializeField] private FruitFactory fruitFactory;

    public void SetFruitInfo(FruitInfo info)
    {
        level = info.level;
        gameObject.name = info.name;
        spriteRenderer.color = info.color;
        transform.localScale = Vector3.one * info.scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchGround = true;

        if (collision.gameObject.TryGetComponent(out Fruit f))
        {
            if (level == f.level)
            {
                // merge!
                if (collision.transform.position.y > transform.position.y)
                {
                    // level up me
                    fruitFactory.LevelUp(this);
                }
                else if (collision.transform.position.y == transform.position.y)
                {
                    if (collision.transform.position.x > transform.position.x)
                    {
                        // level up me
                        fruitFactory.LevelUp(this);
                    }
                    else
                    {
                        // Hide
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    // hide
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
