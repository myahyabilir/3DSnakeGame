using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Sahne işlemlerinin hallediğildiği class.
/// </summary>
public class SceneMenagement : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onScoreGained;
    [SerializeField] private BoolEvent onGameFinishedSuccesful;

    [Header("Variables")]
    private int sceneIndex;
    private int endScore;
    [SerializeField] private IntVariable score;
    [SerializeField] private IntVariable levelEndingPoint;
    [SerializeField] private float fixedDeltaTimeDecreaseValue; 
    [SerializeField] private float hardcoreModeFixedDeltaTime; 
    

    private void OnEnable() {
        onScoreGained.OnEventRaised += IsEndReached;
        onGameFinishedSuccesful.OnEventRaised += GoNextScene;
    }

    private void OnDisable() {
        onScoreGained.OnEventRaised -= IsEndReached;
        onGameFinishedSuccesful.OnEventRaised -= GoNextScene;
    }

    /// <summary>
    /// Yılanın hızı burada sahneye bağlı olarak FixedDeltaTime ile kontrol edilmektedir.
    /// </summary>
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex == 10)
        {
            Time.fixedDeltaTime = hardcoreModeFixedDeltaTime;
            endScore = 99;
        }
        else{
            Time.fixedDeltaTime = 0.06f - ((sceneIndex-1f) * fixedDeltaTimeDecreaseValue);
            endScore = levelEndingPoint.GetValue()*sceneIndex;
        } 
    }

    /// <summary>
    /// Bir levelın tamamlanması için gerekli puana ulaşıp ulaşılmadığını kontrol eder.
    /// </summary>
    /// <param name="scoreToBeAdded"></param>
    private void IsEndReached(int scoreToBeAdded)
    {
        if(score.GetValue() >= endScore)
        {
            onGameFinishedSuccesful.Raise(true);
        }
    }


    /// <summary>
    /// Diğer sahneye geçiş sağlanır. Eğer
    /// </summary>
    /// <param name="isSuccesful"></param>
    private void GoNextScene(bool isSuccesful)
    {
        if(sceneIndex+1 < 10)
        {
            if(isSuccesful) SceneManager.LoadScene(sceneIndex+ 1);
            else SceneManager.LoadScene(1);
        }
        else if(sceneIndex == 9){
            if(isSuccesful) GoToScene(0);
            else GoToScene(1);
        }
        else{
            GoToScene(10);
        }

    }

    public void GoToScene(int index){
        score.SetValue(0);
        SceneManager.LoadScene(index);
    }

}
