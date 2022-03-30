using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject GameWinScreen, GameOverScreen;
    public TextMeshProUGUI livesText, timeText;
    public SpawnManager spawnManager;
    int lives, cubesFilled;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        lives = 3;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //win on 70% cubes filled
        if (GridFillToSeventyPercent())
        {
            //game win
            GameWinScreen.SetActive(true);
            Time.timeScale = 0;
        }

        time += Time.deltaTime;

        livesText.text = "Lives: " + lives.ToString();
        timeText.text = "Time: " + ((int)time).ToString();
    }

    bool GridFillToSeventyPercent()
    {
        if (cubesFilled >= spawnManager.NumberOfCubes() * 0.70)
        {
            return true;
        }
        return false;
    }

    public void ReduceLife()
    {
        lives--;
        if (lives < 0)
        {
            lives = 0;
            //game over
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void FillCube()
    {
        cubesFilled++;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
