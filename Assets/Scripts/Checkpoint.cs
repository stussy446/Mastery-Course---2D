using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovementController player = collision.GetComponent<PlayerMovementController>();
        if (player != null)
        {
            Passed = true;
        }
    }
}
