using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{
    GridManager gridManager;
    GameObject player;
    Node start, finnish;
    int stepCount = 0;

    void Start ()
    {
        gridManager = GameObject.Find ("GridManager").GetComponent<GridManager> ();
        player = gameObject;
    }

    public void Move()
    {
        // start = gridManager.selectedNodes.ToArray()[0]; // get first selected node 
        // finnish = gridManager.selectedNodes.ToArray()[gridManager.selectedNodes.Count]; // get last selected node
        
        stepCount = 0;
        StartCoroutine (Step());
        
    }

    IEnumerator Step()
    {
        yield return new WaitForFixedUpdate();
        
        if (stepCount < gridManager.selectedNodes.Count) {
            
            float step = GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y * 0.2f * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards (transform.position, gridManager.selectedNodes.ToArray()[stepCount].transform.position, step);

            if (Vector2.Distance(gridManager.selectedNodes.ToArray()[stepCount].transform.position, transform.position) < 0.01f)
            {
                stepCount++;
            }

            StartCoroutine (Step());
        } else {
        }
    }
}
