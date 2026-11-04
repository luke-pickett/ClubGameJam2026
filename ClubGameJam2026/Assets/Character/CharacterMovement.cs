using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Rigidbody2D rb;

    private Vector2 velocity = Vector2.zero;
    private Vector2 inputVector = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdateMovement(Vector2 newMovementVector)
    {
        inputVector = newMovementVector;
    }

    void Update()
    {
        velocity = inputVector;
    }

    void FixedUpdate()
    {
        Vector2 cur = transform.position;
        Vector2 newPos = (cur + (velocity * speed));
        rb.MovePosition(newPos);
        velocity = Vector2.zero;
    }
}