using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField]float shellSpeed = 5f;
    
    new Collider2D collider;
    new Rigidbody2D rigidbody2D;
    Vector2 direction;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(direction.x * shellSpeed, rigidbody2D.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            if (collision.WasSide())
            {
                LaunchShell(collision);
                BreakableBox breakableBox = collision.collider.GetComponent<BreakableBox>();

                if (breakableBox != null)
                {
                    Destroy(breakableBox.gameObject);
                }
            }
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();

        if (direction.magnitude == 0)
        {
            LaunchShell(collision);

            if (collision.WasTop())
            {
                playerMovementController.Bounce();

            }
        }
        else
        {
            if (collision.WasTop())
            {
                playerMovementController.Bounce();
                direction = Vector2.zero;
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        var floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        direction = new Vector2(floatDirection, 0);
    }
}
