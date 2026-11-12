using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementRB : MonoBehaviour {
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue iv) {
        Debug.Log(iv.Get<Vector2>());
    }
}
