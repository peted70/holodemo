using UnityEngine;
using System.Collections;

public class StackedBottles : MonoBehaviour
{
    public void ResetBottles()
    {
        var children = GetComponentsInChildren<BottleScript>();
        foreach (var child in children)
        {
            child.Reset();
        }
    }

    public void InitPhysics()
    {
        var children = GetComponentsInChildren<BottleScript>();
        foreach (var child in children)
        {
            child.Placed();
        }
    }
}
