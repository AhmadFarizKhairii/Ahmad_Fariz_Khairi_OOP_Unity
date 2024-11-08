using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;

    private Rigidbody2D rigidBody;
    private float xBoundary;
    private float yBoundary;

    // Initialize Rigidbody2D and set boundaries
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SetBoundaries();
    }

    // Set boundaries based on camera size
    private void SetBoundaries()
    {
        Camera mainCamera = Camera.main;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = mainCamera.aspect * cameraHeight;

        xBoundary = cameraWidth;
        yBoundary = cameraHeight;
    }

    // Process movement input
    public void ExecuteMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movementInput = new Vector2(inputX, inputY).normalized;

        rigidBody.velocity = movementInput * maxSpeed;

        // Ensure the player doesn't move out of bounds
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xBoundary, xBoundary);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yBoundary, yBoundary);
        transform.position = clampedPosition;
    }

    // Check if player is moving
    public bool CheckIfMoving()
    {
        return rigidBody.velocity.magnitude > 0.1f;
    }
}