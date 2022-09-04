using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeShellHits
{

    [SerializeField] private SpriteRenderer enabledSprite;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private int totalCoins = 1;

    private int remainingCoins;
    Animator animator;

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        if (remainingCoins > 0)
        {
            TakeCoin();
        }
    }

    private void Awake()
    {
        remainingCoins = totalCoins;
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 && collision.WasHitByPlayer() && collision.WasBottom())
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
    {
        GameManager.Instance.AddCoin();
        remainingCoins--;
        animator.SetTrigger("FlipCoin");

        if (remainingCoins <= 0)
        {
            enabledSprite.enabled = false;
            disabledSprite.enabled = true;
        }
    }
}
