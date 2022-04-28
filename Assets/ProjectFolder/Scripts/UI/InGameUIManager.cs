using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oyun içi UI'ı ayarlayan classtır.
/// </summary>
public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private BoolVariable isGameStarted;
    [SerializeField] private GameObject tapToStart;
    [SerializeField] private VoidEvent onPointerUp;
    private bool isCoroutinePlayed = false;

    private void OnEnable() {
        onPointerUp.OnEventRaised += StartGame;
    }

    private void OnDisable() {
        onPointerUp.OnEventRaised -= StartGame;
    }

    private void StartGame()
    {
        if(!isCoroutinePlayed)
            StartCoroutine("WaitAndStart");
    }

    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(0.3f);
        isGameStarted.SetValue(true);
        tapToStart.SetActive(false);
        isCoroutinePlayed = true;
    }
}
