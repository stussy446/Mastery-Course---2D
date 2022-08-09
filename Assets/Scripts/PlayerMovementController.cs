using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 400f;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(horizontal, 0, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

}
