using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<ScoreManager>();

            return _instance;
        }
    }

    private static ScoreManager _instance;
    private int score;

    private void Update()
    {
        // TODO Show Score On UI.
        // Debug.Log("***CurrentScore : " + score);
    }

    // Call This Method Everytime The Player Get Points
    public void AddScore(int scoreToAdd){ score += scoreToAdd; }
    public int GetScore() { return score; }
}
