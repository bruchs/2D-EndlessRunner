using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifePoints;
    private bool isAlive;

    private void Update()
    {
        CheckLifeStatus();
    }

    private void CheckLifeStatus()
    {
        if (lifePoints <= 0)
            isAlive = false;
    }

    public void RecieveDamage() { lifePoints -= 1; }
    public bool GetLifeStatus() { return isAlive; }
}