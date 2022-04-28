using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Highscore tablosunun kontrolü sağlanır.
/// </summary>
public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;
    List<GameObject> uiElements = new List<GameObject>();
    List<HighScoreEntry> entryList = new List<HighScoreEntry>();

    void Start()
    {
        UpdateUI(LoadHighscores());
    }

    private List<HighScoreEntry> LoadHighscores () {
        entryList = FileHandler.ReadListFromJSON<HighScoreEntry>("highScoreList.json");
        while (entryList.Count > 5) {
            entryList.RemoveAt(5);
        }

        return entryList;
    }

    private void UpdateUI (List<HighScoreEntry> list) {
        for (int i = 0; i < list.Count; i++) {
            HighScoreEntry el = list[i];

            if (el != null && el.points > 0) {
                if (i >= uiElements.Count) {
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent (elementWrapper, false);

                    uiElements.Add (inst);
                }

                var texts = uiElements[i].GetComponentsInChildren<Text> ();
                texts[0].text = el.date;
                texts[1].text = el.points.ToString();
            }
        }
    }

}
