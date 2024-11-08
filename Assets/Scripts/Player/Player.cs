using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement movement;
    private Animator engineAnimator;

    // Initialize references
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        engineAnimator = transform.Find("Engine/EngineEffect").GetComponent<Animator>();
    }

    // Handle movement
    private void FixedUpdate()
    {
        movement.ExecuteMove();
    }

    // Update animation state
    private void LateUpdate()
    {
        engineAnimator.SetBool("IsMoving", movement.CheckIfMoving());
    }
}