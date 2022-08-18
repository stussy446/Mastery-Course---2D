using UnityEngine;

public class CoinBox : MonoBehaviour
{

    [SerializeField] private SpriteRenderer enabledSprite;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private int totalCoins = 1;

    private int remainingCoins;
    Animator animator;


    private void Awake()
    {
        remainingCoins = totalCoins;
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 && collision.WasHitByPlayer())
        {
            if (collision.WasHitFromBottomSide())
            {
                GameManager.Instance.AddCoin();
                remainingCoins--;
                animator.SetTrigger("FlipCoin");
            }

            if (remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;

            }
        }
    }

}
