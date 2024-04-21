using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private CollisionMessenger messenger;
    [SerializeField] private FruitFactory fruitFactory;

    private void Start()
    {
        messenger.CollisionEvent.AddListener(ProcessCollision);
    }

    private void ProcessCollision(Fruit f, Collision2D collision)
    {
        Debug.Log($"{f.gameObject.name} {f.transform.position}, {collision.gameObject.name} {collision.transform.position}");

        if (collision.transform.position.y > f.transform.position.y)
        {
            // level up me
            fruitFactory.LevelUp(f);
        }
        else if (collision.transform.position.y == f.transform.position.y)
        {
            if (collision.transform.position.x > f.transform.position.x)
            {
                // level up me
                fruitFactory.LevelUp(f);
            }
            else
            {
                // Hide
                f.gameObject.SetActive(false);
            }
        }
        else
        {
            // hide
            f.gameObject.SetActive(false);
        }
    }
}

