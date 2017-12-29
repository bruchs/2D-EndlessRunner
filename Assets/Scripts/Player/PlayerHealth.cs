using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float energyPoints = 100;
    public float onHitForce;

    private bool isAlive = true;
    private Rigidbody2D mRigidbody;
    private PlayerAnimation mPlayerAnimation;
    private PlayerAudio mPlayerAudio;

    private void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mPlayerAnimation = GetComponent<PlayerAnimation>();
        mPlayerAudio = GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        CheckLifeStatus();
    }

    private void FixedUpdate()
    {
        UseEnergy();
    }

    private void UseEnergy()
    {
        energyPoints -= Time.fixedDeltaTime * 3.0F;
    }

    private void CheckLifeStatus()
    {
        if (energyPoints >= 100)
            energyPoints = 100;

        if (energyPoints <= 0)
        {
            KillPlayer();
            energyPoints = 0;
        }
    }

    public void RecieveDamage()
    {
        energyPoints -= 35;
        Vector3 forceVector = new Vector3(-onHitForce * 2, onHitForce, 0.0F);
        mRigidbody.AddForce(forceVector, ForceMode2D.Impulse);

        UIManager.instance.GetUIAnimation().TriggerEnergyLostAnim();
        GameManager.instance.GetCameraEffects().ResetShakeTimer();
    }

    public bool GetLifeStatus() { return isAlive; }
    public int GetCurrentEnergy() { return (int)energyPoints; }
    public void AddEnergy(float energyToAdd) { energyPoints += energyToAdd; }

    public void KillPlayer()
    {
        isAlive = false;
        mPlayerAudio.TriggerSoundEffect(mPlayerAudio.healthSource, mPlayerAudio.destroyedClip);
        Instantiate(Resources.Load("Particles/Player Explosion"), transform.position, transform.rotation, null);

        GameManager.instance.EndGame();
    }
}