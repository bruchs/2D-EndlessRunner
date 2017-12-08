using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<LevelManager>();

            return _instance;
        }
    }

    private static LevelManager _instance;
    public int mediumThreshold, hardThreshold;
    public GameObject[] easyTiles, mediumTiles, hardTiles;

    private int currentDistance = 0;

    private void CheckForCurrentThreshold()
    {
        int CurrentThreshold = ScoreManager.instance.GetScore();

        /* If The CurrentScore Is Greater Than Our 
        Threshold To Check, Spawn The Selected Tiles.*/
        if (CurrentThreshold > hardThreshold)
        {
            SpawnLevel(hardTiles);
            return;
        }
        else if (CurrentThreshold > mediumThreshold)
        {
            SpawnLevel(mediumTiles);
            return;
        }
        else
            SpawnLevel(easyTiles);
    }

    private void SpawnLevel(GameObject[] currentTiles)
    {

    }
}
