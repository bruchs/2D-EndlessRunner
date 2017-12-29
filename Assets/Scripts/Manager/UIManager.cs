using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();

            return _instance;
        }
    }

    private static UIManager _instance;
    public GameObject UIReference;

    private UIAnimation mUIAnimation;
    private UIGame mUIGame;

    private void Start()
    {
        mUIAnimation = UIReference.GetComponent<UIAnimation>();
        mUIGame = UIReference.GetComponent<UIGame>();
    }

    public UIAnimation GetUIAnimation(){ return mUIAnimation; }
    public UIGame GetUIGame() { return mUIGame; }
}
