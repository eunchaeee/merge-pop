using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collision
{
    private Dictionary<Fruit, Vector3> members = new();

    public Collision(Fruit member1, Vector3 member1Pos, Fruit member2, Vector3 member2Pos)
    {
        members.Add(member1, member1Pos);
        members.Add(member2, member2Pos);
    }
}

