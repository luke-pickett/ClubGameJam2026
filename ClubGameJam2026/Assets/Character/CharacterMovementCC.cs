using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementCC : MonoBehaviour {
    private CharacterController cc;

    void Awake() {
        cc = GetComponent<CharacterController>();
    }
    
    void OnMove(InputValue iv) {
        
    }
}
