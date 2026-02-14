using UnityEngine;

public class DamageSpine : MonoBehaviour
{
    public int damage_amount;
    void OnTriggerStay2D(Collider2D other) // When physics system detects an object hitting, triggers the action
    {
        Debug.Log("Object that entered the trigger: " + other);
        PlayerController player = other.GetComponent<PlayerController>(); //contains the reference to the Player Controller (Script) component on GameObject that collides with the collectible.
        if(player != null)
        {
            player.ChangeHealth(damage_amount); // Increase player's health by 20
        }

    
    }
}
