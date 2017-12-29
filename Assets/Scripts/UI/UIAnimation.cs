using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetEnergyStatusAnimation();
    }

    private void SetEnergyStatusAnimation()
    {
        float currentEnergy = GameManager.instance.GetPlayerHealth().GetCurrentEnergy();
        mAnimator.SetFloat("Energy Amount", currentEnergy);
    }

    public void TriggerEnergyCollectedAnim()
    {
        mAnimator.SetTrigger("Energy Collected");
    }

    public void TriggerEnergyLostAnim()
    {
        mAnimator.SetTrigger("Energy Lost");
    }

    public void TriggerGameOverAnimation()
    {
        mAnimator.SetBool("Game Over", true);
    }
}
