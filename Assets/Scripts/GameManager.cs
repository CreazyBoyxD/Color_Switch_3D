using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Collectible[] objectsToCollect;
    [SerializeField] int maxScore;
    [SerializeField] GameObject Player;
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;
    private static bool hasGameStarted = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (!hasGameStarted)
            {
                hasGameStarted = true;
                ResetScore(); // Wyzeruj wynik tylko raz
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        objectsToCollect = new Collectible[0];
        FindObjectsToCollect();
        CalculateMaxScore();

        Player = GameObject.FindGameObjectWithTag("Player");
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();

        score = 0;

        UpdateScoreText();
        foreach (var item in objectsToCollect)
        {
            item.pickupEvent += IncrementScore;
        }
    }

    private void Start()
    {
        FindObjectsToCollect();
        CalculateMaxScore();
        UpdateScoreText();
        foreach (var item in objectsToCollect)
        { 
            item.pickupEvent += IncrementScore; 
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TotalDistance", 0);
        PlayerPrefs.Save();
        score = 0;
    }

    private void FindObjectsToCollect()
    {
        objectsToCollect = GameObject.FindObjectsOfType<Collectible>();
    }

    public void CalculateMaxScore()
    {
        maxScore = objectsToCollect.Length;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Points: " + score;
    }

    public void SavePointsScore()
    {
        int previousScore = PlayerPrefs.GetInt("TotalScore");
        PlayerPrefs.SetInt("TotalScore", previousScore + score);
        PlayerPrefs.Save();
    }

    public void SetSlowTimeScale()
    {
        Time.timeScale = 0.5f;
        Invoke("InvertTime", 1.5f);
    }
    public void InvertTime()
    {
        Time.timeScale = 1f;
    }
}