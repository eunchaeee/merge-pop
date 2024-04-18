using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "ScriptableObject/FruitData")]
public class FruitData : ScriptableObject
{
    [SerializeField] private List<GameObject> fruitList = new();

    public GameObject RandomFruit 
    {
        get 
        {
            return fruitList[Random.Range(0, fruitList.Count)];
        }
    }
}
