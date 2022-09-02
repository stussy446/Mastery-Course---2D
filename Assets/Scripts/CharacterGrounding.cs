using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isGrounded;

    private Transform groundedObject;
    private Vector3? groundObjectLastPosition;

    public bool IsGrounded { get => isGrounded; }
      
    private void Update()
    {

        CheckFootForGrounding(leftFoot);
        if (isGrounded == false)
        {
            CheckFootForGrounding(rightFoot);
        }

        StickToMovingObjects();
    }


    private void CheckFootForGrounding(Transform foot)
    {
        RaycastHit2D rayCastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

        if (rayCastHit.collider != null)
        {
            isGrounded = true;
            groundedObject = rayCastHit.collider.transform;
        }
        else
        {
            isGrounded = false;
            groundedObject = null;
        }

    }

    private void StickToMovingObjects()
    {
        if (groundedObject != null)
        {
            if (groundObjectLastPosition.HasValue &&
                groundObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundObjectLastPosition.Value;
                transform.position += delta;
            }

            groundObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundObjectLastPosition = null;
        }
    }
}
