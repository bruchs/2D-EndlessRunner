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
    public LayerMask GroundLayer;
}
