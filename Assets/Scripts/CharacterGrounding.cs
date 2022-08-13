using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isGrounded;


    public bool IsGrounded { get => isGrounded; }
      


    // Update is called once per frame
    private void Update()
    {

        CheckFootForGrounding(leftFoot);
        if (isGrounded == false)
        {
            CheckFootForGrounding(rightFoot);
        }   


    }


    private void CheckFootForGrounding(Transform foot)
    {
        RaycastHit2D rayCastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

        if (rayCastHit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
