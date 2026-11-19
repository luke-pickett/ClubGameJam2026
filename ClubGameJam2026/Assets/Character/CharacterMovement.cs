using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float skinWidth = 0.05f;

    private Rigidbody2D rb;

    private Vector2 velocity = Vector2.zero;

    private List<RaycastHit2D> hitResults = new List<RaycastHit2D>();

    void MoveWithCollision(Vector2 newPos) {
        Vector2 slope = newPos - rb.position;
        int hits = rb.Cast(slope.normalized, hitResults, slope.magnitude);
        
        if (hits == 0)
        {
            rb.MovePosition(newPos);
            return;
        }

        for (int i=0; i<hits; ++i)
        {
            slope -= (Vector2) Vector3.Project(slope, hitResults[i].normal);
        }
        RaycastHit2D closest = hitResults[0];
        float isAllowed = Mathf.Max(closest.distance - skinWidth, 0);
        Vector2 nonColliding = rb.position + slope.normalized * isAllowed;
        rb.MovePosition(nonColliding);
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
