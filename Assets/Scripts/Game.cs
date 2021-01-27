using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game : MonoBehaviour
{
    public int score { get; set; } = 0;
    public int highScore { get; set; } = 9300;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI highScoreUI;
    public GameObject startScreen;
    public GameObject endScreen;
    public AudioSource music;

    static Game instance = null;

    float timer = 90;

    public enum State
    {
        Title, 
        StartGame,
        Game,
        GameOver
    }

    public State state { get; set; } = State.Title;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Title:
                startScreen.SetActive(true);
                break;
            case State.StartGame:
                timer = 30;
                score = 0;
                startScreen.SetActive(false);
                endScreen.SetActive(false);
                music.Play();
                state = State.Game;
                break;
            case State.Game:
                timer -= Time.deltaTime;
                timerUI.text = string.Format("{0:D2}", (int)timer);
                if(timer <= 0)
                {
                    music.Stop();
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                if (score > highScore) highScore = score;
                highScoreUI.text = string.Format("{0:D4}", highScore);
                endScreen.SetActive(true);
                break;
            default:
                break;
        }


    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    public void addPoints(int points)
    {
        score += points;
        scoreUI.text = string.Format("{0:D4}", score);
    }

    public void startGame()
    {
        state = State.StartGame;
    }
}
