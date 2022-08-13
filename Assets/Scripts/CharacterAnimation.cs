using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IMove))]

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    IMove mover;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", mover.Speed);
    }

}
