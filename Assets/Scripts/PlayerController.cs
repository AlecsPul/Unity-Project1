using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float invincibleTime = 2.0f;
    bool isInvincible;
    float damageCooldown;
    public int health {get{return currentHealth;}}
    public int maxHealth = 100;
    public float speed = 3.0f;
    public int currentHealth;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public InputAction MoveAction;
    private void Start()
    {
        currentHealth = maxHealth;
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        
       
    }
    private void Update()
    {
        move = MoveAction.ReadValue<Vector2>(); // Get the current value of the Move action
        if(isInvincible){
            damageCooldown -= Time.deltaTime;
            if(damageCooldown <= 0)
            {
                isInvincible = false;
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + move *speed * Time.deltaTime; //Time.deltaTime makes the character move the same units for all fps
        transform.position = position;
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvincible)
            {
                return;
            } 
            isInvincible = true;
            damageCooldown = invincibleTime;
            currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        }
        
    }
}
