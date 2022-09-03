using UnityEngine;

public class Walker : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;
    private Vector2 direction = Vector2.left;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.deltaTime);
    }

}
