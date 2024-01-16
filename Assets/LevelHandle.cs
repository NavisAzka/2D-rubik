using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandle : MonoBehaviour
{
    public int expectStep;
    GridManager gridManager;

    void Start ()
    {
        gridManager = GameObject.Find ("GridManager").GetComponent<GridManager> ();
        
    }

    public void CheckLevel ()
    {
        
        if (expectStep <= gridManager.selectedNodes.Count) {
            Debug.Log ("W I N");
        }
    }

}
