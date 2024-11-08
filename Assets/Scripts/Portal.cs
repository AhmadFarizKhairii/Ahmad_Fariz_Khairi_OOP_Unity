using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed = 1f;
    public float rotateSpeed = 50f;
    private Vector3 newPosition;

    void Start()
    {
        ChangePosition();
    }

    void Update()
    {
        // Move towards newPosition and rotate
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        // Check if close to the target position, then update position
        if (Vector3.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }
    }

    void ChangePosition()
    {
        newPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<LevelManager>().ReloadCurrentLevel();
        }
    }
}