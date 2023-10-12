using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public GameObject ballPrefab;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    public static int lives = 3;
    public static int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        drawUI();
        gameOverText.text = "";
    }

    void drawUI()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }

    public void Score()
    {
        score += 1;
        drawUI();
    }

    public void Death()
    {
        lives -= 1;
        if (lives >= 1)
        {
            Instantiate(ballPrefab);
        }
        else
        {
            gameOverText.text = "Game Over";
        }
        drawUI();
    }
}
