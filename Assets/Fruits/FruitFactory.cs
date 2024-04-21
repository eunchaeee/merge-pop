using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitFactory", menuName = "ScriptableObject/FruitFactory")]
public class FruitFactory : ScriptableObject
{
    [SerializeField] private CollisionMessenger collisionMessenger;
    [SerializeField] private List<FruitInfo> fruitInformations = new();

    [SerializeField] private GameObject basePrefab;

    public GameObject InstantiateRandomFruit()
    {
        FruitInfo info = fruitInformations[Random.Range(0, 5)];

        var fruitObj = Instantiate(basePrefab);
        Fruit f = fruitObj.GetComponent<Fruit>();
        f.SetFruitInfo(info);
        f.InjectCollisionMessenger(collisionMessenger);
        return fruitObj;
    }

    public FruitInfo GetFruitInfo(int level)
    {
        return fruitInformations[level];
    }

    public void LevelUp(Fruit fruit)
    {
        fruit.SetFruitInfo(GetFruitInfo(fruit.Level+1));
    }
}
