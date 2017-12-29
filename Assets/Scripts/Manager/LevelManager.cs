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

    [Header("Difficult Threshold")]
    public int mediumThreshold, hardThreshold;
    [Header("Tiles By Difficult")]
    public LevelPiece[] easyTiles, mediumTiles, hardTiles;

    private int currentDistance = 0;
    private float distanceToSpawn = 36.0F;
    private float distanceToAdd;

    private void Start()
    {
        SpawnLevel(easyTiles);
        distanceToSpawn = 36.0F;
        distanceToAdd = distanceToSpawn;
    }

    public void CheckForCurrentThreshold()
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

    private void SpawnLevel(LevelPiece[] currentTiles)
    {
        /* Set The Distance To Instantiate The Tile And Select
           A Random Tile From The Tiles Array */
        
        distanceToSpawn += distanceToAdd; // TODO Change Harcoded Float
        Vector3 spawnPoint = new Vector3(distanceToSpawn, -2.0F, 0.0F);

        /* Select One Of The Level Pieces Randomly and Get One Of It Sections By A Random Value. */
        int randomLevelPieceIndex = Random.Range(0, currentTiles.Length);
        int randomLevelSectionIndex = Random.Range(0, currentTiles[randomLevelPieceIndex].tiles.Length);

        Instantiate(currentTiles[randomLevelPieceIndex].tiles[randomLevelSectionIndex], spawnPoint, 
            currentTiles[randomLevelPieceIndex].tiles[randomLevelSectionIndex].transform.rotation);
    }
}
