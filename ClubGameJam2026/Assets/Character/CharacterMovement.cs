using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float skinWidth = 0.01f;

    private Rigidbody2D rb;

    private Vector2 velocity = Vector2.zero;

    private List<RaycastHit2D> hitResults = new List<RaycastHit2D>();

    void MoveWithCollision(Vector2 newPos) {
        Vector2 slope = newPos - rb.position;
        if (rb.Cast(slope.normalized, hitResults, slope.magnitude) == 0) {
            rb.MovePosition(newPos);
        }
        else {
            RaycastHit2D closest = hitResults[0];
            float isAllowed = Mathf.Max(closest.distance - skinWidth, 0);
            Vector2 nonColliding = rb.position + slope.normalized * isAllowed;
            rb.MovePosition(nonColliding);
        }
    }
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed /= 5;
    }

    

    void OnMove(InputValue input) {
        velocity = input.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 cur = transform.position;
        Vector2 newPos = (cur + (velocity * speed));
        MoveWithCollision(newPos);
    }
}
