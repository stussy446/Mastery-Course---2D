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
            if (direction.magnitude == 0)
            {
                LaunchShell(collision);
            }
            else
            {
                if (collision.WasTop())
                {
                    direction = Vector2.zero;
                }
                else
                {
                    GameManager.Instance.KillPlayer();
                }
            }
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        var floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        direction = new Vector2(floatDirection, 0);
    }
}
