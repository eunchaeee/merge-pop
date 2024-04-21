using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "ScriptableObject/FruitData")]
public class FruitFactory : ScriptableObject
{
    [SerializeField] private List<FruitInfo> fruitInformations = new();

    [SerializeField] private GameObject basePrefab;

    public GameObject InstantiateRandomFruit()
    {
        FruitInfo info = fruitInformations[Random.Range(0, fruitInformations.Count)];

        var fruitObj = Instantiate(basePrefab);
        fruitObj.GetComponent<Fruit>().SetFruitInfo(info);
        return fruitObj;
    }

    public FruitInfo GetFruitInfo(int level)
    {
        return fruitInformations[level];
    }

    public void LevelUp(Fruit fruit)
    {
        fruit.SetFruitInfo(GetFruitInfo(fruit.level+1));
    }
}
