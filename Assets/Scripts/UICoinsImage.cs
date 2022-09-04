using UnityEngine;

public class UICoinsImage : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += AnimateCoinImage;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinsChanged -= AnimateCoinImage;
    }

    private void AnimateCoinImage(int coins)
    {
        animator.SetTrigger("CoinPickedUp");
    }

}
