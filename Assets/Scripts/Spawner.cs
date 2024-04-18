using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FruitData fruitData;
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Camera cam;

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
        currentState = SpawnerState.Holding;
    }

    private void Update()
    {
        switch (currentState)
        {
            case SpawnerState.Holding:
                float x = Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x, xMin, xMax);
                transform.position = new Vector2(x, transform.position.y);
                //Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
                currentFruit.transform.position = transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                    currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    currentFruit = null;
                    currentState = SpawnerState.Dropping;
                }
                
                break;
            case SpawnerState.Dropping:
                Spawn();
                currentState = SpawnerState.Holding;
                break;
        }

    }

    private void Spawn()
    {
        currentFruit = Instantiate(fruitData.fruitList[Random.Range(0, fruitData.fruitList.Count - 1)], transform, true);
    }
}
