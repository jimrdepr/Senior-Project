using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour
{
    Canvas canvas;
    UnityEngine.UI.Text box;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        box = GameObject.Find("Game Over Screen/Text").GetComponentInChildren<Text>();
        canvas.enabled = false;
    }

    public void ShowGameOver()
    {
        canvas.enabled = true;
    }

    public void GameOverText(int score)
    {
        string txt = "Game Over\n" + "Your Score is: " + score.ToString();
        box.text = txt;
    }
}
