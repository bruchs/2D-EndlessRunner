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
    private int highestScore;

    // Call This Method Everytime The Player Get Points
    public void AddScore(int scoreToAdd){ score += scoreToAdd; }
    public int GetScore() { return score + (int)GameManager.instance.GetPlayerMovement().GetTotalDistance(); }
    public void SetHighestScore(int newScore) { highestScore = newScore; }
    public int GetHighestScore() { return highestScore; }
}
