using UnityEngine;

public class Walker : MonoBehaviour, ITakeShellHits
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject spawnOnStompPrefab;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private Vector2 direction = Vector2.left;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge() || HitNotPlayer())
        {
            FlipSprite();
            SwitchDirections();
        }
    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        SpawnShell();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() && collision.WasTop())
        {
            HandleWalkerStomped(collision.collider.GetComponent<PlayerMovementController>());
        }
        else if (collision.WasHitByPlayer())
        {
            GameManager.Instance.KillPlayer();
        }
        
    }

    private void HandleWalkerStomped(PlayerMovementController playerMovementController)
    {
        if (spawnOnStompPrefab != null)
        {
            SpawnShell();
        }
        playerMovementController.Bounce();
        Destroy(gameObject);
    }

    private GameObject SpawnShell()
    {
        return Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);
    }

    private bool ReachedEdge()
    {
        float x = GetForwardX();
        float y = collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);

        Debug.DrawRay(origin, Vector3.down * 0.1f);

        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);
        if (hit.collider == null)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }


    private bool HitNotPlayer()
    {
        float x = GetForwardX();
        float y = transform.position.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, direction * 0.1f);

        var hit = Physics2D.Raycast(origin, direction, 0.1f);

        if (hit.collider != null && hit.collider.GetComponent<PlayerMovementController>() == null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private float GetForwardX()
    {
        return direction.x == -1 ? collider.bounds.min.x - 0.1f : collider.bounds.max.x + 0.1f;
    }

    private void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void SwitchDirections()
    {
        direction *= -1;
    }
}
