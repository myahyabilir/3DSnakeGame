using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Bu class skor sayacını ayarlamaktadır.
/// </summary>
public class CounterController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onScoreGained;
    [SerializeField] private BoolEvent onGameFinishedSuccesful;

    [Header("UI Elements")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    [Header("Variables")]
    [SerializeField] private IntVariable score;
    public List<HighScoreEntry> highscoreList = new List<HighScoreEntry>();
    private string filename = "highScoreList.json";
    private int highScore;
    private int sceneIndex;


    private void OnEnable() {
        onScoreGained.OnEventRaised += UpdateScoreUI;
        onGameFinishedSuccesful.OnEventRaised += ResetCounter;
    }

    private void OnDisable() {
        onScoreGained.OnEventRaised -= UpdateScoreUI;
        onGameFinishedSuccesful.OnEventRaised -= ResetCounter;
    }
    void Start()
    {
        scoreText.text = score.GetValue().ToString();
        LoadHighscores();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(sceneIndex != 10) levelText.text = "Level "+ sceneIndex.ToString();
        else levelText.text = "Hard";
        
    }

    /// <summary>
    /// OnScoreGained raise edildiğinde çalışır ve score global integerını günceller
    /// </summary>
    /// <param name="scoreGained"></param>
    private void UpdateScoreUI(int scoreGained)
    {
        scoreText.text = score.Increase(scoreGained).ToString();
    }

    private void ResetCounter(bool isSuccesful)
    {
        if(isSuccesful) return;
        else
        {
            HighScoreEntry newEntry = new HighScoreEntry(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), score.GetValue());
            AddHighscoreIfPossible(newEntry);
            score.SetValue(0);
        } 
    }

    private void LoadHighscores () {
        highscoreList = FileHandler.ReadListFromJSON<HighScoreEntry> (filename);
        while (highscoreList.Count > 5) {
            highscoreList.RemoveAt(5);
        }
    }

    private void SaveHighscore () {
        FileHandler.SaveToJSON<HighScoreEntry> (highscoreList, filename);
    }

    public void AddHighscoreIfPossible (HighScoreEntry element) {
        for (int i = 0; i < 5; i++) {
            if (i >= highscoreList.Count || element.points > highscoreList[i].points) {
                highscoreList.Insert (i, element);

                while (highscoreList.Count > 5) {
                    highscoreList.RemoveAt(5);
                }
                SaveHighscore();
                break;
            }
        }
    }

}
