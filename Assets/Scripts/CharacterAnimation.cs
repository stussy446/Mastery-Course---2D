using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IMove))]
[RequireComponent(typeof(SpriteRenderer))]

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    IMove mover;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        FlipSpriteIfNeeded(speed);
        
    }

    private void FlipSpriteIfNeeded(float speed)
    {
        if (speed != 0)
        {
            spriteRenderer.flipX = speed > 0;
        }
    }


}
