using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public InputAction MoveAction;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
       
    }
    private void Update()
    {
        move = MoveAction.ReadValue<Vector2>(); // Get the current value of the Move action
        Debug.Log(move);
    }
    void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + move *3.0f * Time.deltaTime; //Time.deltaTime makes the character move the same units for all fps
        transform.position = position;
    }
}
