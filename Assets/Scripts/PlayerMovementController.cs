using UnityEngine;


[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 400f;
    float speed;
    Rigidbody2D rb2d;
    CharacterGrounding characterGrounding;


    public float Speed { get => speed; internal set => speed = value; }


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && characterGrounding.IsGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;

        
    }

}
