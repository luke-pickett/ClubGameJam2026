using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputManager : MonoBehaviour
{
    CharacterMovement movementScript;
    
    void Awake()
    {
        movementScript = GetComponent<CharacterMovement>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue input)
    {
        movementScript.UpdateMovement(input.Get<Vector2>());
    }
}
