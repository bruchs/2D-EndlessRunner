using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float timeToDestroy = 2.5F;

	void Start ()
    {
        Destroy(this.gameObject, timeToDestroy);	
	}
}
