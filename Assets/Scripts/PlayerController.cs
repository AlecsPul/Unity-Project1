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
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move *0.1f;
        transform.position = position;

    }
}
