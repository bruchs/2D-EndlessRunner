using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Text energyText;
    public Text scoreText;

    public Text totalScore;
    public Text totalDistance;

    private void Update()
    {
        SetEnergyText();
        SetScoreText();
    }

    private void SetEnergyText()
    {
        string currentEnergy = GameManager.instance.GetPlayerHealth().GetCurrentEnergy().ToString();
        energyText.text = currentEnergy;
    }

    private void SetScoreText()
    {
        int totalScore = ScoreManager.instance.GetScore();
        scoreText.text = "SCORE: " + totalScore.ToString();
    }

    public void SetResultsUI()
    {
        totalScore.text = "Total Score: " + ScoreManager.instance.GetScore().ToString();
        totalDistance.text = "Total Distance: " + (int)GameManager.instance.GetPlayerMovement().GetTotalDistance() + " Meters";
    }
}
