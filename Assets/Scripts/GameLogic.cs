using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public GameObject ballPrefab;
    public GameObject paddle;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text slowDownPowerText;
    public TMP_Text gameOverText;

    public static int lives = 3;
    public static int score = 0;
    public static bool slowDownEnabled = false;

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
        slowDownPowerText.text = "";
    }

    void Update()
    {
        if (slowDownEnabled)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                float factor = 4;
                if (Time.timeScale != 1f)
                {
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime *= factor;
                    paddle.GetComponent<PaddleMovement>().speed /= factor;
                }
                else
                {
                    Time.timeScale = 1 / factor;
                    Time.fixedDeltaTime /= factor;
                    paddle.GetComponent<PaddleMovement>().speed *= factor;
                }
            }
        }
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

    public void EnableSlowDown()
    {
        slowDownEnabled = true;
        slowDownPowerText.text = "Press \"s\" to slow down time!";
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
