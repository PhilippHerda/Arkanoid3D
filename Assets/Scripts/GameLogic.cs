using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public TMP_Text livesText;
    public TMP_Text scoreText;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score()
    {
        score += 1;
        drawUI();
    }

    void drawUI()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }
}
