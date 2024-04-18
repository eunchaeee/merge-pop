using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "ScriptableObject/FruitData")]
public class FruitData : ScriptableObject
{
    public List<GameObject> fruitList = new();
}
