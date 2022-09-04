using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField] private Transform[] positions;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isGrounded;

    private Transform groundedObject;
    private Vector3? groundObjectLastPosition;

    public bool IsGrounded { get => isGrounded; }
    public Vector2 GroundedDirection { get; private set; }
      
    private void Update()
    {
        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (isGrounded) { break; }
 
        }

        StickToMovingObjects();
    }


    private void CheckFootForGrounding(Transform position)
    {
        RaycastHit2D rayCastHit = Physics2D.Raycast(position.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(position.position, position.forward * maxDistance, Color.red);

        if (rayCastHit.collider != null)
        {
            if (groundedObject != rayCastHit.collider.transform)
            {
                groundObjectLastPosition = rayCastHit.collider.transform.position;
            }
            groundedObject = rayCastHit.collider.transform;
            isGrounded = true;
            GroundedDirection = position.forward;
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
