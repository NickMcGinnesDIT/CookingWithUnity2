using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ep03GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static int High = 0;

    public static bool GameOver = false;


    private void Update()
    {
        High = High < Score ? Score : High;

        if (GameOver && Input.GetKeyDown(KeyCode.Z))
        {
            Score = 0;
            GameOver = false;
            SceneManager.LoadScene("ep03");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 120, 20), "Score: " + Score.ToString());
        GUI.Label(new Rect(120, 0, 120, 20), "Highscore: " + High.ToString());

        if (GameOver)
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 120, 20), "Game Over!");
    }
}