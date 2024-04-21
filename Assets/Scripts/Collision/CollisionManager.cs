using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private CollisionMessenger messenger;
    [SerializeField] private FruitFactory fruitFactory;

    private void Start()
    {
        messenger.CollisionEvent.AddListener(ProcessCollision);
    }

    private void ProcessCollision(Transform t, Collision2D collision)
    {
        Debug.Log($"CollisionManager::ProcessCollision {collision}");
        Fruit f = t.GetComponent<Fruit>();

        if (collision.transform.position.y > t.position.y)
        {
            // level up me
            fruitFactory.LevelUp(f);
        }
        else if (collision.transform.position.y == t.position.y)
        {
            if (collision.transform.position.x > t.position.x)
            {
                // level up me
                fruitFactory.LevelUp(f);
            }
            else
            {
                // Hide
                t.gameObject.SetActive(false);
            }
        }
        else
        {
            // hide
            t.gameObject.SetActive(false);
        }
    }
}

