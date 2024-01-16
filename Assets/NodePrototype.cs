using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePrototype
{
    public bool isPlaceable;
    public Vector3 cellPosition;
    public Transform obj;

    

    public NodePrototype(bool isPlaceable, Vector3 cellPosition, Transform obj)
    {
        this.isPlaceable = isPlaceable;
        this.cellPosition = cellPosition;
        this.obj = obj;
    }
}