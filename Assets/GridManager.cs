using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GridManager : MonoBehaviour
{
    public Transform CellPrefab;
    [SerializeField] private int height; // SerializeField let us change value in the inspector
    [SerializeField] private int width;
    [SerializeField] private float gapX, gapY;
    GameObject parent;
    public Node[,] nodes;
    public Node current;
    public Queue<Node> selectedNodes = new Queue<Node>();
    
    
    void Start ()
    {
        MakeGrid();
    }

    void Update  ()
    {
    
    }

    public void MakeGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        parent = new GameObject("PARENT");
        parent.transform.parent = transform;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i * gapX + transform.position.x, j * gapY + transform.position.y, 0);
                Transform obj = Instantiate(CellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell " + name;
                obj.parent = parent.transform;
                obj.gameObject.AddComponent<Node> ().indexPosX =  i;
                obj.gameObject.GetComponent<Node> ().indexPosY =  j;
                nodes [i,j] = obj.GetComponent<Node> ();
                
                new NodePrototype(true, worldPosition, obj);
                name++; 
                
            }
        }
        ClearGrid();
    }

    public void UpdateCurrentNode (Node newNode)
    {
        ClearGrid();
        Node before = null;

        if (current != null) 
        {
            before = current;
        }
        
        current = newNode;
        
        //Debug.Log (current.indexPosX + " " + before.indexPosX);
        
      
        for (int i = 0; i < height; i++)
        {
            nodes[current.indexPosX,i].GetComponent<SpriteRenderer> ().color = Color.green;
        }
        
        for (int i = 0; i < width; i++)
        {
            nodes[i,current.indexPosY].GetComponent<SpriteRenderer> ().color = Color.green;
        }



        if (current != null && before != null)
        {
        
            if (current.indexPosX == before.indexPosX) // vertically 
            {
                if (before.indexPosY < current.indexPosY) 
                {
                    for (int i = before.indexPosY ; i <= current.indexPosY; i++)
                    {
                        if (!selectedNodes.Contains(nodes[current.indexPosX,i])) 
                        {
                            selectedNodes.Enqueue(nodes[current.indexPosX,i].GetComponent<Node> ());
                            nodes[current.indexPosX,i].GetComponent<SpriteRenderer> ().color = Color.red;
                        }
                    }
                }
                else
                {
                    for (int i = before.indexPosY ; i >= current.indexPosY; i--)
                    {
                        if (!selectedNodes.Contains(nodes[current.indexPosX,i])) 
                        {
                            selectedNodes.Enqueue(nodes[current.indexPosX,i].GetComponent<Node> ());
                            nodes[current.indexPosX,i].GetComponent<SpriteRenderer> ().color = Color.red;
                        }
                    }
                }
            }
            else if (current.indexPosY == before.indexPosY) // horizontally
            {
                if (before.indexPosX < current.indexPosX) 
                {
                    for (int i = before.indexPosX ; i <= current.indexPosX; i++)
                    {
                        if (!selectedNodes.Contains(nodes[i,current.indexPosY])) 
                        {
                            selectedNodes.Enqueue(nodes[i,current.indexPosY].GetComponent<Node> ());
                            nodes[i,current.indexPosY].GetComponent<SpriteRenderer> ().color = Color.red;
                        }
                    }
                }
                else
                {
                    for (int i = before.indexPosX ; i >= current.indexPosX; i--)
                    {
                        if (!selectedNodes.Contains(nodes[i,current.indexPosY])) 
                        {
                            selectedNodes.Enqueue(nodes[i,current.indexPosY].GetComponent<Node> ());
                            nodes[i,current.indexPosY].GetComponent<SpriteRenderer> ().color = Color.red;
                        }
                    }
                }
            } 
            else // not both
            {
                ClearSelectedNode();
            }           
            
            ChangeColor();
        }

    }

    void ClearGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                nodes[i,j].GetComponent<SpriteRenderer> ().color = Color.gray;
            }   
        }

        
    }

    void ChangeColor()
    {
        Node[] temp = selectedNodes.ToArray();
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].GetComponent<SpriteRenderer> ().color = Color.red;
            //Debug.Log (temp[i].transform.GetChild(0));
            temp[i].transform.GetChild(0).GetComponent<TextMeshProUGUI> ().text = (i + 1).ToString();
        }
    }

    void ClearSelectedNode()
    {
        while (selectedNodes.Count > 0)
        {
            selectedNodes.Dequeue().transform.GetChild(0).GetComponent<TextMeshProUGUI> ().text = "";
        }
    }


}
