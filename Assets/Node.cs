using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{   

   public int indexPosX,indexPosY;
   void OnMouseDown()
   {
         //Debug.Log (name);
         GetComponent<SpriteRenderer> ().color = Color.cyan;

         transform.parent.parent.GetComponent<GridManager> ().UpdateCurrentNode ( this);

       // Code here is called when the GameObject is clicked on.
   }
}
