using System;

/// <summary>
/// İçerisinde Highscore'a ait olan tarih ve puanı barındıracak olan class.
/// </summary>
[Serializable]
public class HighScoreEntry {
    public string date;
    public int points;

    public HighScoreEntry (string date, int points) {
        this.date = date;
        this.points = points;
    }
}
