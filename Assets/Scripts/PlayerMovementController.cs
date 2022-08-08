using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
