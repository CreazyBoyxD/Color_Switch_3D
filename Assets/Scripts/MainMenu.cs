using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI points;
    public TextMeshProUGUI distance;

    private void Start()
    {
        DisplayTotalDistance();
    }

    void DisplayTotalDistance()
    {
        int totalDistance = PlayerPrefs.GetInt("TotalDistance");
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        distance.text = totalDistance.ToString();
        points.text = totalScore.ToString();
    }

    public void PlayGame()
    { 
        SceneManager.LoadScene(1);
        GameManager.instance.ResetScore();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Levels()
    {
        SceneManager.LoadScene(8);
    }

}
