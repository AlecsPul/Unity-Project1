using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public InputAction MoveAction;
    private void Start()
    {
        MoveAction.Enable();
       
    }
    private void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>(); // Get the current value of the Move action
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move *3.0f * Time.deltaTime; //Time.deltaTime makes the character move the same units for all fps
        transform.position = position;

    }
}
