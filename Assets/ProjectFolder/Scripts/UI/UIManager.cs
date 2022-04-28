using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ana menü UI controlleru
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScenePanel;
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject scenesPanel;
    
    private void Start()
    {
        OpenMainScenePanel();
    }

    public void OpenMainScenePanel()
    {
        mainScenePanel.SetActive(true);
        highScorePanel.SetActive(false);
        scenesPanel.SetActive(false);
    }

    public void OpenHighScorePanel()
    {
        mainScenePanel.SetActive(false);
        highScorePanel.SetActive(true);
        scenesPanel.SetActive(false);
    }

    public void OpenScenePanel()
    {
        mainScenePanel.SetActive(false);
        highScorePanel.SetActive(false);
        scenesPanel.SetActive(true);
    }

}
