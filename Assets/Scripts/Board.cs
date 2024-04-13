using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject cellPrefabs;

    public Transform board;
    public GridLayoutGroup gridLayout;

    public string currentTurn = "x";
    public string[,] matrix;
    public int boardSize;
    public void Awake()
    {

    }
    public void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];
        gridLayout.constraintCount = boardSize;

        CreateBoard();
    }
    private void CreateBoard()
    {
        for (int i = 1; i <= boardSize; i++)
        {
            for (int j = 1; j <= boardSize; j++)
            {
                GameObject cellTransform = Instantiate(cellPrefabs, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.collum = j;
                matrix[i, j] = "";
            }
        }
    }
    public bool Check(int row, int collum)
    {
        matrix[row, collum] = currentTurn;
        bool result = false;
        int count = 0;
        //check hàng dọc
        for (int i = row - 1; i >= 1; i--)
        {
            if (matrix[i, collum] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i <= boardSize; i++)
        {
            if (matrix[i, collum] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            return true;
        }
        //check hàng ngang
        count = 0;
        for (int i = collum - 1; i >= 1; i--)
        {
            if (matrix[row, i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = collum + 1; i <= boardSize; i++)
        {
            if (matrix[row, i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            return true;
        }
        // Check hang cheo 1
        count = 0;
        for (int i = collum - 1; i >= 1; i--) // cheo tren trai
        {
            if (matrix[row - (collum - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        for (int i = collum + 1; i <= boardSize; i++) // cheo duoi phai
        {
            if (matrix[row + (collum - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        if (count + 1 >= 5)
        {
            return  true;
        }
        // Check hang cheo 2
        count = 0;
        for (int i = collum + 1; i <= boardSize; i++) // cheo tren phai
        {
            if (matrix[row - (collum - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = collum - 1; i >= 1; i--) // cheo duoi trai
        {
            if (matrix[row + (collum - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            return  true;
        }
        return result;
    }
}
