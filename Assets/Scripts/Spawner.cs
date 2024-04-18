using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FruitData fruitData;
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform pool;

    private GameObject currentFruit;
    private SpawnerState currentState;

    private float xMin;
    private float xMax;

    public enum SpawnerState
    {
        Holding,
        Dropping
    }

    private void Start()
    {
        xMin = leftWall.position.x;
        xMax = rightWall.position.x;

        Spawn();
    }

    private void Update()
    {
        switch (currentState)
        {
            case SpawnerState.Holding:
                float x = Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x, xMin, xMax);
                transform.position = new Vector2(x, transform.position.y);
                if (Input.GetMouseButtonDown(0))
                {
                    currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    ChangeState(SpawnerState.Dropping);
                }               
                break;
            case SpawnerState.Dropping:
                if (currentFruit.GetComponent<CollisionChecker>().isTouchGround)
                {
                    currentFruit.transform.parent = pool;
                    Spawn();
                }
                break;
        }

    }

    private void Spawn()
    {
        currentFruit = Instantiate(fruitData.fruitList[Random.Range(0, fruitData.fruitList.Count - 1)], transform, true);
        currentFruit.transform.localPosition = Vector3.zero;
        ChangeState(SpawnerState.Holding);
    }

    private void ChangeState(SpawnerState state)
    {
        switch (state)
        {
            case SpawnerState.Dropping:
                currentState = SpawnerState.Dropping; break;
            case SpawnerState.Holding:
                currentState = SpawnerState.Holding; break;
        }
    }
}
