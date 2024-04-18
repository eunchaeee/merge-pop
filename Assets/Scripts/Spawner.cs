using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FruitData fruitData;

    private GameObject currentFruit;
    private SpawnerState currentState;

    public enum SpawnerState
    {
        HoldFruit,
        Dropping
    }

    private void Start()
    {
        Spawn();
        currentState = SpawnerState.HoldFruit;
    }

    private void Update()
    {
        switch (currentState)
        {
            case SpawnerState.HoldFruit:
                currentFruit.transform.position = transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                    currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    currentState = SpawnerState.Dropping;
                }

                break;
            case SpawnerState.Dropping:
                Spawn();
                currentState = SpawnerState.HoldFruit;
                break;
        }

    }

    private void Spawn()
    {
        currentFruit = Instantiate(fruitData.fruitList[Random.Range(0, fruitData.fruitList.Count - 1)], transform, true);
    }
}
