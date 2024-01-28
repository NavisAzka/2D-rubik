using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubikHandler : MonoBehaviour
{
    public GameObject[] mainBlock;
    public GameObject[] secondaryBlock;
    public Color tempBlockColor;
    public string tempBlocText;
    public int size = 3;

    public void SwapRight (int indexRow)
    {
        indexRow *= size;

        tempBlocText = mainBlock[indexRow + size - 1].transform.GetChild(0).GetComponent<Text>().text;
        
        for (int i = size - 1; i > 0; i--) {
            mainBlock[indexRow + i].transform.GetChild(0).GetComponent<Text>().text =  mainBlock[indexRow + i - 1].transform.GetChild(0).GetComponent<Text>().text;
        }
        
        mainBlock[indexRow].transform.GetChild(0).GetComponent<Text>().text =  tempBlocText;
    }

    public void SwapLeft (int indexRow) 
    {
        indexRow *= size;

        tempBlocText = mainBlock[indexRow].transform.GetChild(0).GetComponent<Text>().text;
        
        for (int i = 0; i < size - 1; i++) {
            mainBlock[indexRow + i].transform.GetChild(0).GetComponent<Text>().text =  mainBlock[indexRow + i + 1].transform.GetChild(0).GetComponent<Text>().text;
        }
        
        mainBlock[indexRow + size - 1].transform.GetChild(0).GetComponent<Text>().text = tempBlocText; 
    }

    public void SwapUp (int indexCol)
    {
        tempBlocText = mainBlock[indexCol + 0].transform.GetChild(0).GetComponent<Text>().text;
        
        for (int i = 0; i < size - 1; i++) {
            mainBlock[indexCol + size * i].transform.GetChild(0).GetComponent<Text>().text = mainBlock[indexCol + size * (i + 1)].transform.GetChild(0).GetComponent<Text>().text;
        }
        
        mainBlock[indexCol + size * (size - 1)].transform.GetChild(0).GetComponent<Text>().text =  tempBlocText;
    }

    public void SwapDown (int indexCol)
    {
        tempBlocText = mainBlock[indexCol + size * (size - 1)].transform.GetChild(0).GetComponent<Text>().text; 
        
        for (int i = size - 1; i > 0; i--) {
            mainBlock[indexCol + size * i].transform.GetChild(0).GetComponent<Text>().text = mainBlock[indexCol + size * (i - 1)].transform.GetChild(0).GetComponent<Text>().text;
        }
        
        mainBlock[indexCol + 0].transform.GetChild(0).GetComponent<Text>().text = tempBlocText;
    }

}
