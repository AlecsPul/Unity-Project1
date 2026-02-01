using UnityEngine;

public class HealthCrystal : MonoBehaviour
{
    public int healing_amount;
    void OnTriggerEnter2D(Collider2D other) // When physics system detects an object hitting, triggers the action
    {
        Debug.Log("Object that entered the trigger: " + other);
        PlayerController player = other.GetComponent<PlayerController>(); //contains the reference to the Player Controller (Script) component on GameObject that collides with the collectible.
        if(player != null && player.health != player.maxHealth)
        {
            player.ChangeHealth(healing_amount); // Increase player's health by 20
            Destroy(gameObject); // Destroy the collectible
        }
    }
}
