using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject gameOverWindow;
    private Transform canvas;
    public int row;
    public int collum;
    public Board board;
    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private Button button;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void Start()
    {
        board = FindObjectOfType<Board>();
        canvas = FindObjectOfType<Canvas>().transform;
    }
    public void ChangeImage(string s)
    {
        if(s == "x")
        {
            image.sprite = xSprite;
        }  
        else
        {
            image.sprite = oSprite;
        }    
    }    
    public void OnClick()
    {
        ChangeImage(board.currentTurn);
        if(board.Check(this.row, this.collum))
        {
            GameObject window =  Instantiate(gameOverWindow,canvas);
            window.GetComponent<GameOverWindow>().Setname(board.currentTurn);
        }    
        if(board.currentTurn == "x")
        {
            board.currentTurn = "o";
        } 
        else
        {
            board.currentTurn = "x";
        }    
    }    
}
