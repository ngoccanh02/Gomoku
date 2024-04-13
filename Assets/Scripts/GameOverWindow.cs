using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverWindow : MonoBehaviour
{
    public Text winnerName;
    public Button ResetGame;
    public void Awake()
    {
        ResetGame.onClick.AddListener(OnClick);
    }
    public void Setname(string s)
    {
        winnerName.text = s;
    } 
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
