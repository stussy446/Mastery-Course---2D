using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMovementController playerMovementController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", playerMovementController.Speed);
    }

}
